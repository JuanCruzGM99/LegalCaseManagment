using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Interfaces;
using Services.Composite;

namespace Services
{
    public class SessionManager
    {
        private static object Lock = new Object();
        private static SessionManager Session;
        public EEUsuario Usuario { get; set; }

        private SessionManager()
        {
        }

        public static SessionManager GetInstance
        {
            get
            {
                if (Session == null) throw new Exception("La sesion no está iniciada");
                return Session;
            }
        }

        public static void Login(EEUsuario usuario)
        {
            lock (Lock)
            {
                if (Session == null)
                {
                    Session = new SessionManager();
                    Session.Usuario = usuario;
                }
                else
                {
                    throw new Exception("La sesion ya estaba iniciada");
                }
            }
        }

        public static void Logout()
        {
            lock (Lock)
            {
                if (Session != null)
                {
                    Session = null;
                }
                else
                {
                    throw new Exception("La sesion no se inicio correctamente");
                }
            }
        }

        public bool IsInRole(Enum tipoPermiso)
        {
            if (Usuario == null)
                return false;

            foreach (IPermiso permiso in Usuario.Permisos)
            {
                if (TienePermisoRecursivo(permiso, tipoPermiso))
                    return true;
            }

            return false;
        }

        private bool TienePermisoRecursivo(IPermiso permiso, Enum tipoPermiso)
        {
            Patente patente = permiso as Patente;
            if (patente != null && patente.Tipo.HasValue && patente.Tipo.Value.Equals(tipoPermiso))
                return true;

            foreach (IPermiso hijo in permiso.ObtenerHijos())
            {
                if (TienePermisoRecursivo(hijo, tipoPermiso))
                    return true;
            }

            return false;
        }
    }
}
