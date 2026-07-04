using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
	public class BLLLogin
	{
        public bool CrearUsuario(EEUsuario oUsuario)
        {
            MPPUsuario mPPUsuario = new MPPUsuario();
            bool resultado;
            resultado = mPPUsuario.CrearUsuario(oUsuario);
            return resultado;
        }

        public bool ModificarUsuario(EEUsuario oUsuario)
        {
            MPPUsuario mPPUsuario = new MPPUsuario();
            bool resultado;
            resultado = mPPUsuario.CrearUsuario(oUsuario);
            return resultado;
        }
        public List<EEUsuario> ListarUsuario()
        {
            List<EEUsuario> lista = new List<EEUsuario>();
            MPPUsuario mPPUsuario = new MPPUsuario();
            return lista = mPPUsuario.ListarUsuarios();
        }

        public EEUsuario ListarUnUser(EEUsuario _Usuario)
        {
            EEUsuario User = new EEUsuario();
            MPPUsuario MPP_User = new MPPUsuario();
            return User = MPP_User.ListarUn_User(_Usuario);
        }

        public EEUsuario Logear(string Username, string Password)
        {
            EEUsuario _Usuario = new EEUsuario();
            EEUsuario _Usuario2 = new EEUsuario();
            BLLLogin _Login = new BLLLogin();

            _Usuario.Username = Username;
            _Usuario.Password = Password;
            _Usuario2 = _Login.ListarUnUser(_Usuario);

            return _Usuario2;
        }

        //[NBL002] INICIO - Se agrega el metodo ObtenerPorNombre
        public EEUsuario ObtenerPorNombre(string nombreUsuario)
        {
            MPPUsuario mPPUsuario = new MPPUsuario();
            return mPPUsuario.ObtenerPorNombre(nombreUsuario);
        }
        //[NBL002] FIN

    }
}
