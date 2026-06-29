using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BLLBitacora
    {
        MPPBitacora mppBitacora = new MPPBitacora();

        public List<EEBitacora> Listar(DateTime? fechaDesde, DateTime? fechaHasta, TimeSpan? horaDesde, TimeSpan? horaHasta, string actividad, string usuario)
        {
            return mppBitacora.Listar(fechaDesde, fechaHasta, horaDesde, horaHasta, actividad, usuario);
        }
    }
}