using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BLLPersona //[NBL005]
    {
        private MPPPersona mppPersona = new MPPPersona();

        public bool Crear(EEPersona persona)
        {
            return mppPersona.Crear(persona);
        }

        public bool Modificar(EEPersona persona)
        {
            return mppPersona.Modificar(persona);
        }

        public List<EEPersona> Listar()
        {
            return mppPersona.Listar();
        }

        public List<EEPersona> ListarActivas()
        {
            return mppPersona.ListarActivas();
        }
    }
}
