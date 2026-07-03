using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BLLParte //[NBL005]
    {
        private MPPParte mppParte = new MPPParte();

        public bool Crear(EEParte parte)
        {
            return mppParte.Crear(parte);
        }

        public List<EEParte> ListarPorSiniestro(int idSiniestro)
        {
            return mppParte.ListarPorSiniestro(idSiniestro);
        }
    }
}