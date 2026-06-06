using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace Services
{
    public class SessionManager
    {
        private static object Lock = new Object();
        private static SessionManager Session;
        private static Sesion _instancia;

        public EEUsuario Usuario { get; set; }

        public static SessionManager GetInstance
        {
            get
            {
                if (Session == null) throw new Exception("La sesion ya estaba iniciada");

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
                    //throw new Exception("La sesion no se inicio correctamente");
                }
            }


        }

        private SessionManager()
        {

        }
    }
}
