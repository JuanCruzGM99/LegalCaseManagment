using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using Services;
using Services.Composite;
using Interfaces;

namespace UI
{
    public partial class GestorPermisos : Form
    {
        BLLUsuario _bllusuarios;
        FamiliaBLL _bllFamilias;
        EEUsuario _usuario;

        private ComboBox cboFamilias;
        private Button btnAsignarFamilia;
        private Button btnQuitarFamilia;
        private Label lblFamilias;

        public GestorPermisos()
        {
            _bllusuarios = new BLLUsuario();
            _bllFamilias = new FamiliaBLL();

            InitializeComponent();
            InicializarControlesAsignacion();
            CargarUsuarios();
            CargarFamilias();
        }

        private void InicializarControlesAsignacion()
        {
            this.Size = new Size(390, 470);

            lblFamilias = new Label();
            lblFamilias.Text = "Familia:";
            lblFamilias.Location = new Point(38, 355);
            lblFamilias.AutoSize = true;
            this.Controls.Add(lblFamilias);

            cboFamilias = new ComboBox();
            cboFamilias.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFamilias.Location = new Point(38, 378);
            cboFamilias.Size = new Size(196, 21);
            this.Controls.Add(cboFamilias);

            btnAsignarFamilia = new Button();
            btnAsignarFamilia.Text = "Asignar";
            btnAsignarFamilia.Location = new Point(245, 376);
            btnAsignarFamilia.Size = new Size(95, 25);
            btnAsignarFamilia.Click += btnAsignarFamilia_Click;
            this.Controls.Add(btnAsignarFamilia);

            btnQuitarFamilia = new Button();
            btnQuitarFamilia.Text = "Quitar selección";
            btnQuitarFamilia.Location = new Point(245, 407);
            btnQuitarFamilia.Size = new Size(95, 25);
            btnQuitarFamilia.Click += btnQuitarFamilia_Click;
            this.Controls.Add(btnQuitarFamilia);
        }

        private void CargarUsuarios()
        {
            var users = _bllusuarios.GetAll().ToList();

            this.cboUsuarios.DataSource = null;
            this.cboUsuarios.DisplayMember = "Username";
            this.cboUsuarios.ValueMember = "ID";
            this.cboUsuarios.DataSource = users;
        }

        private void CargarFamilias()
        {
            var familias = _bllFamilias.GetAll().ToList();

            this.cboFamilias.DataSource = null;
            this.cboFamilias.DisplayMember = "Nombre";
            this.cboFamilias.DataSource = familias;
        }

        private void cboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            _usuario = this.cboUsuarios.SelectedItem as EEUsuario;
            MostrarPermisos();
        }

        private TreeNode CrearNodo(IPermiso item)
        {
            TreeNode tn = new TreeNode(item.Nombre);
            tn.Tag = item;
            return tn;
        }

        private void MostrarPermisosRecursivo(IPermiso p, TreeNode tn)
        {
            foreach (var item in p.ObtenerHijos())
            {
                var tnn = CrearNodo(item);
                tn.Nodes.Add(tnn);

                if (item.ObtenerHijos().Count > 0)
                {
                    MostrarPermisosRecursivo(item, tnn);
                }
            }
        }

        private void MostrarPermisos()
        {
            this.treeView1.Nodes.Clear();

            if (_usuario != null)
            {
                TreeNode raiz = new TreeNode("Permisos de " + _usuario.Username);
                this.treeView1.Nodes.Add(raiz);

                foreach (var item in _usuario.Permisos)
                {
                    var tn = CrearNodo(item);
                    raiz.Nodes.Add(tn);

                    if (item.ObtenerHijos().Count > 0)
                    {
                        MostrarPermisosRecursivo(item, tn);
                    }
                }

                this.treeView1.ExpandAll();
            }
        }

        private void btnAsignarFamilia_Click(object sender, EventArgs e)
        {
            if (_usuario == null || cboFamilias.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un usuario y una familia.");
                return;
            }

            IFamilia familia = cboFamilias.SelectedItem as IFamilia;
            _bllFamilias.AsignarFamiliaAUsuario(_usuario, familia);

            RecargarPermisosUsuario();
            MessageBox.Show("Familia asignada.");
        }

        private void btnQuitarFamilia_Click(object sender, EventArgs e)
        {
            if (_usuario == null || treeView1.SelectedNode == null || !(treeView1.SelectedNode.Tag is IFamilia))
            {
                MessageBox.Show("Seleccioná una familia del árbol para quitarla del usuario.");
                return;
            }

            IFamilia familia = treeView1.SelectedNode.Tag as IFamilia;
            _bllFamilias.QuitarFamiliaAUsuario(_usuario, familia);

            RecargarPermisosUsuario();
            MessageBox.Show("Familia quitada si estaba asignada directamente al usuario.");
        }

        private void RecargarPermisosUsuario()
        {
            if (_usuario == null)
                return;

            _usuario.Permisos.Clear();
            foreach (var familia in _bllFamilias.ListarPorUsuario(_usuario.ID))
            {
                _usuario.Permisos.Add(familia);
            }

            MostrarPermisos();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }

        private void GestorPermisos_Load(object sender, EventArgs e)
        {
        }
    }
}
