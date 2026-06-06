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

        EEUsuario _usuario;
        public GestorPermisos()
        {
            _bllusuarios = new BLLUsuario();
            InitializeComponent();

            var users = _bllusuarios.GetAll();
            //List<EEUsuario> users = _bllusuarios.ListarUsers();
            this.cboUsuarios.DataSource = users;
        }

        private void cboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            _usuario = (EEUsuario)this.cboUsuarios.SelectedItem;
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
            if (_usuario != null)
            {
                this.treeView1.Nodes.Clear();
                TreeNode raiz = new TreeNode("Permisos");
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
            }



        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void GestorPermisos_Load(object sender, EventArgs e)
        {

        }
    }
}
