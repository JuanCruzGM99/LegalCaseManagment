using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL //[NBL004] Se crea clase BLLSiniestro
{
    public class BLLSiniestro
    {
        MPPSiniestro mppSiniestro = new MPPSiniestro();

        public bool Crear(EESiniestro siniestro)
        {
            return mppSiniestro.Crear(siniestro);
        }

        public bool Modificar(EESiniestro siniestro, int idUser)
        {
            return mppSiniestro.Modificar(siniestro, idUser);
        }

        public List<EESiniestro> Listar()
        {
            return mppSiniestro.Listar();
        }

        public EESiniestro ObtenerPorId(int idSiniestro)
        {
            return mppSiniestro.ObtenerPorId(idSiniestro);
        }

        public List<EEControlCambioSiniestro> ListarCambiosPorSiniestro(int idSiniestro)
        {
            return mppSiniestro.ListarCambiosPorSiniestro(idSiniestro);
        }

        public List<EEHistorialSiniestro> ListarHistorialPorSiniestro(int idSiniestro)
        {
            return mppSiniestro.ListarHistorialPorSiniestro(idSiniestro);
        }

        public bool RestaurarDesdeHistorial(int idHistorialSiniestro, int idUser)
        {
            return mppSiniestro.RestaurarDesdeHistorial(idHistorialSiniestro, idUser);
        }
    }
}