using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE //[NBL004] Se crea clase EEHistorialSiniestro
{
    public class EEHistorialSiniestro
    {
        public int IDHistorialSiniestro { get; set; }
        public int IDSiniestro { get; set; }
        public string Usuario { get; set; }

        public string NumeroSiniestro { get; set; }
        public string Caratula { get; set; }
        public string AnalistaInterno { get; set; }
        public DateTime? FechaSiniestro { get; set; }
        public string LugarSiniestro { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }

        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string Accion { get; set; }
    }
}
