using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class EEPersona
    {
        public int IDPersona { get; set; }
        public string NombreRazonSocial { get; set; }
        public string CUIT { get; set; }
        public string CBU { get; set; }
        public string Observaciones { get; set; }
        public bool Activo { get; set; }
    }
}