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
        FamiliaBLL _bllFamilias = new FamiliaBLL();
        Encriptador en = new Encriptador();
        public BLLUsuario()
        {
            _crud = new UsuarioDAL();
            SimularDatos();
        }
        public bool CrearUser(EEUsuario _Usuario)
        {
            MPPUsuario MPP_User = new MPPUsuario();
            bool resultado;
            resultado = MPP_User.CrearUsuario(_Usuario);
            return resultado;
        }
        public List<EEUsuario> ListarUsers()
        {
            List<EEUsuario> List_User = new List<EEUsuario>();
            MPPUsuario MPP_User = new MPPUsuario();
            return List_User = MPP_User.ListarUsuarios();
        }
        private void SimularDatos()
        {


            _bllFamilias.SimularDatos();

            //u1 puede gestionar usuarios
            var u = new EEUsuario();
            u.Email = "u1@mail.com";
            u.Password = en.Encriptar("123");
            var f = _bllFamilias.GetAll().Where(ff => ff.Nombre.Contains("Gestores de usuarios")).FirstOrDefault();
            if (f != null) u.Permisos.Add(f);

            _crud.Save(u);


            //u2 puede gestionar permisos
            u = new EEUsuario();
            u.Email = "u2@mail.com";
            u.Password = en.Encriptar("123");
            f = _bllFamilias.GetAll().Where(ff => ff.Nombre.Contains("Gestores de permisos")).FirstOrDefault();
            if (f != null) u.Permisos.Add(f);
            _crud.Save(u);


            //admin tiene todo
            u = new EEUsuario();
            u.Email = "admin@mail.com";
            u.Password = en.Encriptar("123");
            f = _bllFamilias.GetAll().Where(ff => ff.Nombre.Contains("Administradores")).FirstOrDefault();
            if (f != null) u.Permisos.Add(f);

            _crud.Save(u);
        }

    }
}
