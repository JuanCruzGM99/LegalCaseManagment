using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL //[NBL006]
{ 
    public class LineaPagoDocumento
    {
        public string Concepto { get; set; }
        public string Beneficiario { get; set; }
        public string CUIT { get; set; }
        public decimal Importe { get; set; }
        public string FechaPago { get; set; }
        public string FormaPago { get; set; }
        public string CBU { get; set; }
    }
}