using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BLL //[NBL006]
{
    public class ContextoDocumentoLegal
    {
        public EESiniestro Siniestro { get; set; }
        public List<EEParte> Partes { get; set; }
        public Dictionary<int, List<EEIntegranteParte>> IntegrantesPorParte { get; set; }
        public List<EEVehiculo> Vehiculos { get; set; }

        public ContextoDocumentoLegal()
        {
            Partes = new List<EEParte>();
            IntegrantesPorParte = new Dictionary<int, List<EEIntegranteParte>>();
            Vehiculos = new List<EEVehiculo>();
        }

        public List<EEIntegranteParte> ObtenerIntegrantesPorTipoParte(string tipoParte)
        {
            EEParte parte = Partes.FirstOrDefault(p => p.TipoParte == tipoParte);

            if (parte == null)
                return new List<EEIntegranteParte>();

            if (!IntegrantesPorParte.ContainsKey(parte.IDParte))
                return new List<EEIntegranteParte>();

            return IntegrantesPorParte[parte.IDParte];
        }

        public EEIntegranteParte ObtenerPrimerIntegrantePorTipoParte(string tipoParte)
        {
            return ObtenerIntegrantesPorTipoParte(tipoParte).FirstOrDefault();
        }

        public List<EEIntegranteParte> ObtenerIntegrantesConMonto()
        {
            List<EEIntegranteParte> integrantes = new List<EEIntegranteParte>();

            foreach (var item in IntegrantesPorParte)
            {
                integrantes.AddRange(item.Value.Where(i => i.Monto.HasValue));
            }

            return integrantes;
        }
    }
}
