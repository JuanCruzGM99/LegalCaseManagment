using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BLLTipoParte //[NBL005]
    {
        private MPPTipoParte mppTipoParte = new MPPTipoParte();

        public List<EETipoParte> Listar()
        {
            return mppTipoParte.Listar();
        }
    }
}
