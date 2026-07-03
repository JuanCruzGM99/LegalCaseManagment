using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BLLVehiculo
    {
        private MPPVehiculo mppVehiculo = new MPPVehiculo();

        public bool Crear(EEVehiculo vehiculo)
        {
            return mppVehiculo.Crear(vehiculo);
        }

        public List<EEVehiculo> ListarPorSiniestro(int idSiniestro)
        {
            return mppVehiculo.ListarPorSiniestro(idSiniestro);
        }
    }
}
