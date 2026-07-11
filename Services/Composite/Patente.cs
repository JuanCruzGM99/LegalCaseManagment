using BE;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Composite
{
    public class Patente : Permiso, IPatente
    {
        public string Codigo { get; set; }

        public TipoPermiso? Tipo { get; set; }

        public override void AgregarPermiso(IPermiso p)
        {
            throw new InvalidOperationException("Una 'Patente' es una hoja y no puede contener hijos.");
        }

        public override IList<IPermiso> ObtenerHijos()
        {
            return new List<IPermiso>();
        }

        public override void QuitarPermiso(IPermiso p)
        {
            throw new InvalidOperationException("Una 'Patente' es una hoja y no puede contener hijos.");
        }
    }
}
