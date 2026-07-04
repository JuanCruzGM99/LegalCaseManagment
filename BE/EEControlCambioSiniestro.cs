using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE //[NBL004] Se crea clase EEControlCambioSiniestro
{
    public class EEControlCambioSiniestro
    {
        public int IDControlCambio { get; set; }
        public int IDSiniestro { get; set; }
        public int? IDHistorialSiniestro { get; set; }
        public string Usuario { get; set; }
        public string Campo { get; set; }
        public string ValorAnterior { get; set; }
        public string ValorNuevo { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
    }
}
