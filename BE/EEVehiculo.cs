using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class EEVehiculo
    {
        public int IDVehiculo { get; set; }
        public int IDSiniestro { get; set; }

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Dominio { get; set; }
        public string Observaciones { get; set; }
    }
}
