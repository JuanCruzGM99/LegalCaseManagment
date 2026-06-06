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
using System.Resources;
using System.Globalization;

namespace UI
{
	public partial class LogIn : Form
	{
		BLLLogin BLLUsuario = new BLLLogin();
		EEUsuario eEUsuario = new EEUsuario();
		EEUsuario eEUsuario2 = new EEUsuario();
		EEUsuario eeUsuarioLogIn = new EEUsuario();
		BLLUsuario _usuarioBLL;
		public LogIn()
		{
			InitializeComponent();
			_usuarioBLL = new BLLUsuario();
		}
		

        public void logear(string usuario, string contraseña)
        {
            eEUsuario.Username = usuario;
            eEUsuario.Password = contraseña;
            eEUsuario2 = BLLUsuario.ListarUnUser(eEUsuario);


            if (eEUsuario2 != null)
            {              
				SessionManager.Login(eeUsuarioLogIn);
				SessionManager u = SessionManager.GetInstance;
				MessageBox.Show("Inicio de sesion correcto");
				Menu menuFinal = new Menu();
                menuFinal.Show();
				this.Hide();
			}
            else
            { MessageBox.Show("Usuario incorrecto"); }
        }

		private void btnSesion_Click(object sender, EventArgs e)
		{
			try
			{
				logear(txtUsuario.Text, txtContraseña.Text);
			}
			catch (LoginException error)
			{
				switch (error.Result)
				{
					case LoginResult.InvalidUsername:
						MessageBox.Show("Usuario incorrecto");
						break;
					case LoginResult.InvalidPassword:
						MessageBox.Show("Password Incorrecto");
						break;

					default:
						break;
				}

			}

		}

		private void LogIn_Load(object sender, EventArgs e)
		{

		}

		private void LogIn_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
			SessionManager.Logout();
		}
	}
}
