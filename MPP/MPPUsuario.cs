using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using System.Data;
using Services;

namespace MPP
{
    public class MPPUsuario
    {
        Encriptador encriptador = new Encriptador();
        public bool CrearUsuario(EEUsuario _User)
        {
            try
            {
                Acceso dal = new Acceso();
                Hashtable hs = new Hashtable();
                bool resultado;

                string consulta = "s_Usuario_Crear";
                hs.Add("@NombreUsuario", _User.Username);
                hs.Add("@Contraseña", _User.Password);

                resultado = dal.Escribir(consulta, hs);
                return resultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<EEUsuario> ListarUsuarios()
        {
            Acceso dal = new Acceso();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            List<EEUsuario> list_users = new List<EEUsuario>();
            EEUsuario User = default(EEUsuario);

            ds = dal.Leer("S_Usuarios_Listar", null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    User = new EEUsuario();
                    User.ID = Convert.ToInt32(item["IDUser"]);
                    User.Username = item["NombreUsuario"].ToString();
					User.Password = encriptador.Desencriptar(item["Contraseña"].ToString());
					//User.Password = item["Contraseña"].ToString();

					list_users.Add(User);
                }
                return list_users;
            }
            else
            {
                return null;
            }

        }

        public EEUsuario ListarUn_User(EEUsuario User)
        {
            Acceso dal = new Acceso();
            DataSet ds = new DataSet();
            Hashtable hs = new Hashtable();
            EEUsuario e_Usuario = default(EEUsuario);

            hs.Add("@Username", User.Username);
            hs.Add("@Password", encriptador.Encriptar(User.Password));

            ds = dal.Leer("s_ListarUnUser", hs);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    e_Usuario = new EEUsuario();
                    e_Usuario.Username = item["NombreUsuario"].ToString();
					e_Usuario.Password = encriptador.Desencriptar(item["Contraseña"].ToString());
					//e_Usuario.Password = item["Contraseña"].ToString();
				}
                return User;
            }
            else
            {
                return null;
            }
        }

        //[NBL002] INICIO - Se agrega el metodo ObtenerPorNombre
        public EEUsuario ObtenerPorNombre(string nombreUsuario)
        {
            Acceso acceso = new Acceso();
            DataSet ds = new DataSet();
            Hashtable parametros = new Hashtable();

            parametros.Add("@NombreUsuario", nombreUsuario);

            ds = acceso.Leer("s_Usuario_ObtenerPorNombre", parametros);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow item = ds.Tables[0].Rows[0];

                EEUsuario usuario = new EEUsuario();
                usuario.ID = Convert.ToInt32(item["IDUser"]);
                usuario.Username = item["NombreUsuario"].ToString();
                usuario.Password = encriptador.Desencriptar(item["Contraseña"].ToString());

                return usuario;
            }

            return null;
        }
        //[NBL002] FIN

    }
}
