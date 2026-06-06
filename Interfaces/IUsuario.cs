using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUsuario
    {
        string Email { get; set; }
        string Password { get; set; }


        IList<IPermiso> Permisos { get; }
    }
}
