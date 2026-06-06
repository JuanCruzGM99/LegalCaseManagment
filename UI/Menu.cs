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
			Application.Exit();
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
    }
}
