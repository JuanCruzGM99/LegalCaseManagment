using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace BE
{
    public class EEUsuario : Entity, IUsuario
    {
        private IList<IPermiso> _permisos;

        public EEUsuario()
        {
            _permisos = new List<IPermiso>();
        }

        public int ID { get; set; }
        public string Username { get; set; }
        public String Password { get; set; }
        public string Email { get; set; }

        public IList<IPermiso> Permisos
        {
            get
            {
                return _permisos;
            }
        }

        public override string ToString()
        {
            return Username;
        }
    }
}
