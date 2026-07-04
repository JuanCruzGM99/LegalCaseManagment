using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BLL //[NBL006]
{
    public class BLLDocumentoLegal
    {
        private BLLSiniestro bllSiniestro = new BLLSiniestro();
        private BLLParte bllParte = new BLLParte();
        private BLLIntegranteParte bllIntegranteParte = new BLLIntegranteParte();
        private BLLVehiculo bllVehiculo = new BLLVehiculo();

        public string GenerarDocumento(int idSiniestro, string tipoDocumento)
        {
            ContextoDocumentoLegal contexto = CrearContexto(idSiniestro);

            CreadorDocumentoLegal creador = ObtenerCreador(tipoDocumento);

            return creador.GenerarDocumento(contexto);
        }

        private ContextoDocumentoLegal CrearContexto(int idSiniestro)
        {
            ContextoDocumentoLegal contexto = new ContextoDocumentoLegal();

            contexto.Siniestro = bllSiniestro.ObtenerPorId(idSiniestro);
            contexto.Partes = bllParte.ListarPorSiniestro(idSiniestro);
            contexto.Vehiculos = bllVehiculo.ListarPorSiniestro(idSiniestro);

            foreach (EEParte parte in contexto.Partes)
            {
                List<EEIntegranteParte> integrantes = bllIntegranteParte.ListarPorParte(parte.IDParte);

                contexto.IntegrantesPorParte.Add(parte.IDParte, integrantes);
            }

            return contexto;
        }

        private CreadorDocumentoLegal ObtenerCreador(string tipoDocumento)
        {
            if (tipoDocumento == TiposDocumentoLegal.AcuerdoLegal)
            {
                return new CreadorAcuerdoLegal();
            }

            if (tipoDocumento == TiposDocumentoLegal.FormularioPago)
            {
                return new CreadorFormularioPagoLegal();
            }

            throw new Exception("Tipo de documento no reconocido.");
        }
    }
}