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
		BLLBitacora bllBitacora = new BLLBitacora(); //[NBL002]
		EEUsuario eEUsuario = new EEUsuario();
		EEUsuario eEUsuario2 = new EEUsuario();
		EEUsuario eeUsuarioLogIn = new EEUsuario();
		BLLUsuario _usuarioBLL;
		public LogIn()
		{
			InitializeComponent();
			_usuarioBLL = new BLLUsuario();
		}

		//[NBL002] INICIO - Se reemplaza completo el metodo loguear
		/*
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
		*/
		//[NBL002] FIN 

		public void logear(string usuario, string contraseña)
		{
			string nombreUsuario = usuario.Trim();

			EEUsuario usuarioEncontrado = BLLUsuario.ObtenerPorNombre(nombreUsuario);

			if (usuarioEncontrado == null)
			{
				EEUsuario usuarioAnonimo = BLLUsuario.ObtenerPorNombre("anonimo");

				if (usuarioAnonimo != null)
				{
					bllBitacora.Crear(usuarioAnonimo.ID, "Login fallido - usuario inexistente");
				}

				MessageBox.Show("Usuario incorrecto");
				return;
			}

			if (usuarioEncontrado.Password != contraseña)
			{
				bllBitacora.Crear(usuarioEncontrado.ID, "Login fallido - contraseña incorrecta");

				MessageBox.Show("Password Incorrecto");
				return;
			}

			bllBitacora.Crear(usuarioEncontrado.ID, "Login exitoso");

			SessionManager.Login(usuarioEncontrado);

			MessageBox.Show("Inicio de sesion correcto");

			Menu menuFinal = new Menu();
			menuFinal.Show();

			this.Hide();
		}

		//[NBL002] INICIO - Se reemplaza completo el evento btnSesion_Click
		/*
		private void btnSesion_Click(object sender, EventArgs e)
		{
			try
			{
				logear(txtUsuario.Text, txtContraseña.Text);
				//bitacora login exitoso
			}
			catch (LoginException error)
			{
				switch (error.Result)
				{
					case LoginResult.InvalidUsername:
						MessageBox.Show("Usuario incorrecto");
                        //bitacora login fallido user inexistente(crear user default para cargar en la bitacora.
                        break;
					case LoginResult.InvalidPassword:
						MessageBox.Show("Password Incorrecto");
                        //bitacora login fallido password incorrecto
                        break;

					default:
						break;
				}
			}
		}*/
		//[NBL002] FIN 

		private void btnSesion_Click(object sender, EventArgs e)
		{
			try
			{
				logear(txtUsuario.Text, txtContraseña.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al iniciar sesión: " + ex.Message);
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
