using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Services.Composite
{
	public abstract class Permiso: ServiceEntity, IPermiso
    {
        public string Nombre { get; set; }


        public abstract void AgregarPermiso(IPermiso p);
        public abstract void QuitarPermiso(IPermiso p);
        public abstract IList<IPermiso> ObtenerHijos();

        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
