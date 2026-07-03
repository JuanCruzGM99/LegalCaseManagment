using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class EEParte
    {
        public int IDParte { get; set; }
        public int IDSiniestro { get; set; }
        public int IDTipoParte { get; set; }

        public string TipoParte { get; set; }
        public string Observaciones { get; set; }
    }
}
