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

                string consulta = "s_Usuario_Crear";
                hs.Add("@NombreUsuario", _User.Username);
                hs.Add("@Contraseña", _User.Password);

                return dal.Escribir(consulta, hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EEUsuario> ListarUsuarios()
        {
            Acceso dal = new Acceso();
            DataSet ds = dal.Leer("S_Usuarios_Listar", null);
            List<EEUsuario> list_users = new List<EEUsuario>();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    EEUsuario user = new EEUsuario();
                    user.ID = Convert.ToInt32(item["IDUser"]);
                    user.Username = item["NombreUsuario"].ToString();
                    user.Password = encriptador.Desencriptar(item["Contraseña"].ToString());

                    CargarPermisos(user);
                    list_users.Add(user);
                }
            }

            return list_users;
        }

        public EEUsuario ListarUn_User(EEUsuario User)
        {
            Acceso dal = new Acceso();
            DataSet ds = new DataSet();
            Hashtable hs = new Hashtable();
            EEUsuario e_Usuario = null;

            hs.Add("@Username", User.Username);
            hs.Add("@Password", encriptador.Encriptar(User.Password));

            ds = dal.Leer("s_ListarUnUser", hs);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow item = ds.Tables[0].Rows[0];
                e_Usuario = new EEUsuario();

                if (item.Table.Columns.Contains("IDUser"))
                    e_Usuario.ID = Convert.ToInt32(item["IDUser"]);

                e_Usuario.Username = item["NombreUsuario"].ToString();
                e_Usuario.Password = encriptador.Desencriptar(item["Contraseña"].ToString());

                CargarPermisos(e_Usuario);
            }

            return e_Usuario;
        }

        public EEUsuario ObtenerPorNombre(string nombreUsuario)
        {
            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();
            parametros.Add("@NombreUsuario", nombreUsuario);

            DataSet ds = acceso.Leer("s_Usuario_ObtenerPorNombre", parametros);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow item = ds.Tables[0].Rows[0];

                EEUsuario usuario = new EEUsuario();
                usuario.ID = Convert.ToInt32(item["IDUser"]);
                usuario.Username = item["NombreUsuario"].ToString();
                usuario.Password = encriptador.Desencriptar(item["Contraseña"].ToString());

                CargarPermisos(usuario);
                return usuario;
            }

            return null;
        }

        private void CargarPermisos(EEUsuario usuario)
        {
            if (usuario == null || usuario.ID <= 0)
                return;

            usuario.Permisos.Clear();

            FamiliaDAL familiaDAL = new FamiliaDAL();
            foreach (var familia in familiaDAL.ListarPorUsuario(usuario.ID))
            {
                usuario.Permisos.Add(familia);
            }
        }
    }
}
