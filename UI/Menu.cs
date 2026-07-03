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

namespace UI
{
	public partial class Menu : Form
	{
		BLLUsuario _bllUsuarios;
		private bool cerrandoSesion = false; //[NBL003]
		BLLBitacora bllBitacora = new BLLBitacora();//[NBL001]

		public Menu()
		{
			InitializeComponent();
			//valido permisos
			//this.mnuGestorPermisos.Enabled = SessionManager.Instancia.IsInRole(TipoPermiso.GestorPermiso);
			//this.mnuGestorUsuarios.Enabled = SessionManager.Instancia.IsInRole(TipoPermiso.GestorUsuario);
			_bllUsuarios = new BLLUsuario();
		}

		private void Menu_Load(object sender, EventArgs e)
		{
			  
		}

		private void Menu_FormClosed(object sender, FormClosedEventArgs e)
		{
			//[NBL003] Se agrega condicion para que al cerrar sesion no se cierre la aplicacion.
			if (!cerrandoSesion)
			{
				Application.Exit();
			}
		}

		private void agregarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CrearUser crearUser = new CrearUser();
			crearUser.MdiParent = this;
			crearUser.Show();
		}

		private void gestionDeToolStripMenuItem_Click(object sender, EventArgs e)
		{

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

		
		private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e) //[NBL003] Se agrega evento para cerrar sesion
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
        
		private void gestionarSiniestrosToolStripMenuItem_Click(object sender, EventArgs e) //[NBL004] Se agrega evento para Gestion de Siniestros
		{
			GestionSiniestros frm = new GestionSiniestros();
			frm.MdiParent = this;
			frm.Show();
		}
	}
}
