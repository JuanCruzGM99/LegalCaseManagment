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
        DigitoVerificador digitoVerificador = new DigitoVerificador();

        public bool CrearUsuario(EEUsuario _User)
        {
            try
            {
                Acceso dal = new Acceso();
                Hashtable hs = new Hashtable();

                string consulta = "s_Usuario_Crear";
                hs.Add("@NombreUsuario", _User.Username);
                hs.Add("@Contraseña", _User.Password);
                hs.Add("@DVH", digitoVerificador.CalcularDVHUsuario(_User.Username, _User.Password));

                bool resultado = dal.Escribir(consulta, hs);

                if (resultado)
                    ActualizarDVVUsuarios();

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EEUsuario> ListarUsuarios()
        {
            VerificarIntegridadUsuarios();

            Acceso dal = new Acceso();
            DataSet ds = dal.Leer("S_Usuarios_Listar", null);
            List<EEUsuario> list_users = new List<EEUsuario>();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    ValidarDVHDeFilaUsuario(item);

                    EEUsuario user = new EEUsuario();
                    user.ID = Convert.ToInt32(item["IDUser"]);
                    user.Username = item["NombreUsuario"].ToString().Trim();
                    user.Password = encriptador.Desencriptar(item["Contraseña"].ToString());

                    CargarPermisos(user);
                    list_users.Add(user);
                }
            }

            return list_users;
        }

        public EEUsuario ListarUn_User(EEUsuario User)
        {
            VerificarIntegridadUsuarios();

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
                ValidarDVHDeFilaUsuario(item);

                e_Usuario = new EEUsuario();

                if (item.Table.Columns.Contains("IDUser"))
                    e_Usuario.ID = Convert.ToInt32(item["IDUser"]);

                e_Usuario.Username = item["NombreUsuario"].ToString().Trim();
                e_Usuario.Password = encriptador.Desencriptar(item["Contraseña"].ToString());

                CargarPermisos(e_Usuario);
            }

            return e_Usuario;
        }

        public EEUsuario ObtenerPorNombre(string nombreUsuario)
        {
            VerificarIntegridadUsuarios();

            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();
            parametros.Add("@NombreUsuario", nombreUsuario);

            DataSet ds = acceso.Leer("s_Usuario_ObtenerPorNombre", parametros);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow item = ds.Tables[0].Rows[0];
                ValidarDVHDeFilaUsuario(item);

                EEUsuario usuario = new EEUsuario();
                usuario.ID = Convert.ToInt32(item["IDUser"]);
                usuario.Username = item["NombreUsuario"].ToString().Trim();
                usuario.Password = encriptador.Desencriptar(item["Contraseña"].ToString());

                CargarPermisos(usuario);
                return usuario;
            }

            return null;
        }

        public bool VerificarIntegridadUsuarios()
        {
            Acceso acceso = new Acceso();
            DataSet ds = acceso.Leer("s_DigitoVerificador_Usuario_Verificar", null);

            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return true;

            DataRow fila = ds.Tables[0].Rows[0];
            int dvvCalculado = Convert.ToInt32(fila["DVVCalculado"]);
            int dvvPersistido = Convert.ToInt32(fila["DVVPersistido"]);

            if (dvvCalculado != dvvPersistido)
                throw new Exception("Error de integridad: el digito verificador vertical de Usuario no coincide.");

            return true;
        }

        public bool ActualizarDVVUsuarios()
        {
            Acceso acceso = new Acceso();
            return acceso.Escribir("s_DigitoVerificador_Usuario_Recalcular", null);
        }

        private void ValidarDVHDeFilaUsuario(DataRow item)
        {
            if (!item.Table.Columns.Contains("DVH"))
                throw new Exception("La tabla Usuario no posee la columna DVH. Ejecutar el script de digito verificador.");

            string nombreUsuario = item["NombreUsuario"].ToString();
            string passwordEncriptada = item["Contraseña"].ToString();
            int dvhPersistido = Convert.ToInt32(item["DVH"]);

            if (!digitoVerificador.ValidarDVHUsuario(nombreUsuario, passwordEncriptada, dvhPersistido))
                throw new Exception("Error de integridad: el digito verificador horizontal del usuario '" + nombreUsuario.Trim() + "' no coincide.");
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
