using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;
using BLL;
using BE;

namespace UI
{
    public partial class Menu : Form
    {
        BLLUsuario _bllUsuarios;
        private bool cerrandoSesion = false;
        BLLBitacora bllBitacora = new BLLBitacora();

        public Menu()
        {
            InitializeComponent();
            _bllUsuarios = new BLLUsuario();
            AplicarPermisosMenu();
        }

        private void AplicarPermisosMenu()
        {
            bool puedeGestionarPermisos = false;
            bool puedeGestionarUsuarios = false;

            try
            {
                puedeGestionarPermisos = SessionManager.GetInstance.IsInRole(TipoPermiso.GestorPermiso);
                puedeGestionarUsuarios = SessionManager.GetInstance.IsInRole(TipoPermiso.GestorUsuario);
            }
            catch
            {
                // Si no hay sesión iniciada, se dejan deshabilitados.
            }

            this.mnuGestorPermisos.Enabled = puedeGestionarPermisos;
            this.mnuGestorUsuarios.Enabled = puedeGestionarUsuarios;
            this.agregarUsuarioToolStripMenuItem.Enabled = puedeGestionarUsuarios;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!cerrandoSesion)
            {
                Application.Exit();
            }
        }

        private void agregarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirCrearUsuario();
        }

        private void gestionDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirCrearUsuario();
        }

        private void AbrirCrearUsuario()
        {
            CrearUser crearUser = new CrearUser();
            crearUser.MdiParent = this;
            crearUser.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void gestionDePermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestorPermisos frm = new GestorPermisos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void verBitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerBitacora frm = new VerBitacora();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Desea cerrar sesión?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                if (SessionManager.GetInstance != null && SessionManager.GetInstance.Usuario != null)
                {
                    bllBitacora.Crear(SessionManager.GetInstance.Usuario.ID, "Logout exitoso");
                }

                cerrandoSesion = true;
                SessionManager.Logout();

                LogIn login = new LogIn();
                login.Show();

                this.Close();
            }
        }

        private void gestionarSiniestrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionSiniestros frm = new GestionSiniestros();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
