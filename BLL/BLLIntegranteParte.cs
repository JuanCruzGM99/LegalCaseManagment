using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BLLIntegranteParte //[NBL005]
    {
        private MPPIntegranteParte mppIntegranteParte = new MPPIntegranteParte();

        public bool Crear(EEIntegranteParte integranteParte)
        {
            return mppIntegranteParte.Crear(integranteParte);
        }

        public List<EEIntegranteParte> ListarPorParte(int idParte)
        {
            return mppIntegranteParte.ListarPorParte(idParte);
        }
    }
}
