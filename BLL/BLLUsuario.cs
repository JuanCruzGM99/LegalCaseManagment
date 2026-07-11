using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP;
using BE;
using Services;
using DAL;

namespace BLL
{
    public class BLLUsuario : AbstractBLL<EEUsuario>
    {
        public BLLUsuario()
        {         
            _crud = new UsuarioDAL();
        }

        public bool CrearUser(EEUsuario _Usuario)
        {
            MPPUsuario MPP_User = new MPPUsuario();
            return MPP_User.CrearUsuario(_Usuario);
        }

        public List<EEUsuario> ListarUsers()
        {
            MPPUsuario MPP_User = new MPPUsuario();
            return MPP_User.ListarUsuarios() ?? new List<EEUsuario>();
        }

        public new IList<EEUsuario> GetAll()
        {
            return ListarUsers();
        }

        public bool VerificarIntegridadUsuarios()
        {
            MPPUsuario MPP_User = new MPPUsuario();
            return MPP_User.VerificarIntegridadUsuarios();
        }

        public bool RecalcularDigitosVerificadoresUsuarios()
        {
            MPPUsuario MPP_User = new MPPUsuario();
            return MPP_User.ActualizarDVVUsuarios();
        }
    }
}
