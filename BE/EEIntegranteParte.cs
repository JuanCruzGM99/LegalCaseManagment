using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class EEIntegranteParte
    {
        public int IDIntegranteParte { get; set; }
        public int IDParte { get; set; }
        public int IDPersona { get; set; }

        public string NombreRazonSocial { get; set; }
        public string CUIT { get; set; }
        public string CBU { get; set; }

        public decimal? Monto { get; set; }
        public string PlazoPago { get; set; }
        public bool EsPrincipal { get; set; }
        public string Observaciones { get; set; }
    }
}
