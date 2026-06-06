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

namespace UI
{
	public partial class CrearUser : Form
	{
		public CrearUser()
		{
			InitializeComponent();
			ActualizarDGVUsuario();
		}
		EEUsuario eEUsuario = new EEUsuario();
		BLLLogin bLLLogincs = new BLLLogin();
		Encriptador encriptador = new Encriptador();
		private void CrearUser_Load(object sender, EventArgs e)
		{

		}
		public void Modificardgvs()
		{
			dgvUsuarios.DefaultCellStyle.ForeColor = Color.Black;
		}
		public void ActualizarDGVUsuario()
		{
			dgvUsuarios.DataSource = null;
			dgvUsuarios.DataSource = bLLLogincs.ListarUsuario();
		}

		public void LimpiarTxts()
		{
			txtUser.Text = "";
			txtContraseña.Text = "";
		}

		private void btnAgregarUsuario_Click(object sender, EventArgs e)
		{
			eEUsuario.Username = txtUser.Text;
			//Encriptado de contraseña
			eEUsuario.Password = encriptador.Encriptar(txtContraseña.Text);
			bLLLogincs.CrearUsuario(eEUsuario);

			LimpiarTxts();
			ActualizarDGVUsuario();
		}

		private void dgvUsuarios_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.ColumnIndex != 0)
			{
				txtID.Text = Convert.ToString(dgvUsuarios.Rows[e.RowIndex].Cells[0].Value);
				txtUser.Text = Convert.ToString(dgvUsuarios.Rows[e.RowIndex].Cells[1].Value);
				txtContraseña.Text = Convert.ToString(dgvUsuarios.Rows[e.RowIndex].Cells[2].Value);
			}
		}
	}
}
