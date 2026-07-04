using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class EEBitacora
    {
        public int IDBitacora { get; set; }
        public string Usuario { get; set; }
        public string Actividad { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
    }
}
