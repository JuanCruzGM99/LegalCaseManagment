using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BLL //[NBL006]
{
    public class AcuerdoLegal : DocumentoLegal
    {
        public override string NombreDocumento
        {
            get { return "Acuerdo legal"; }
        }

        public override List<string> Validar(ContextoDocumentoLegal contexto)
        {
            List<string> errores = new List<string>();

            if (contexto == null || contexto.Siniestro == null)
            {
                errores.Add("No se encontró el siniestro.");
                return errores;
            }

            if (string.IsNullOrWhiteSpace(contexto.Siniestro.NumeroSiniestro))
                errores.Add("El siniestro debe tener número.");

            if (string.IsNullOrWhiteSpace(contexto.Siniestro.Caratula))
                errores.Add("El siniestro debe tener carátula.");

            if (!contexto.Siniestro.FechaSiniestro.HasValue)
                errores.Add("El acuerdo requiere fecha del siniestro.");

            if (string.IsNullOrWhiteSpace(contexto.Siniestro.LugarSiniestro))
                errores.Add("El acuerdo requiere lugar del siniestro.");

            if (!contexto.ObtenerIntegrantesPorTipoParte(TiposParteDocumento.Requirente).Any())
                errores.Add("Debe existir al menos un requirente.");

            if (!contexto.ObtenerIntegrantesPorTipoParte(TiposParteDocumento.Mediador).Any())
                errores.Add("Debe existir un mediador.");

            if (!contexto.ObtenerIntegrantesPorTipoParte(TiposParteDocumento.LetradoRequirente).Any())
                errores.Add("Debe existir un letrado requirente.");

            if (!contexto.ObtenerIntegrantesPorTipoParte(TiposParteDocumento.LetradoCompania).Any())
                errores.Add("Debe existir un letrado de la compañía.");

            if (!contexto.ObtenerIntegrantesPorTipoParte(TiposParteDocumento.Requirente).Any(i => i.Monto.HasValue))
                errores.Add("Debe cargarse el monto de capital del requirente.");

            return errores;
        }

        public override string GenerarVistaPrevia(ContextoDocumentoLegal contexto)
        {
            StringBuilder sb = new StringBuilder();

            List<EEIntegranteParte> requirentes = contexto.ObtenerIntegrantesPorTipoParte(TiposParteDocumento.Requirente);
            EEIntegranteParte mediador = contexto.ObtenerPrimerIntegrantePorTipoParte(TiposParteDocumento.Mediador);
            EEIntegranteParte letradoRequirente = contexto.ObtenerPrimerIntegrantePorTipoParte(TiposParteDocumento.LetradoRequirente);
            EEIntegranteParte letradoCompania = contexto.ObtenerPrimerIntegrantePorTipoParte(TiposParteDocumento.LetradoCompania);
            EEIntegranteParte capital = requirentes.FirstOrDefault(i => i.Monto.HasValue);

            sb.AppendLine("ACUERDO LEGAL - VISTA PREVIA");
            sb.AppendLine("======================================");
            sb.AppendLine();

            sb.AppendLine("Siniestro N°: " + contexto.Siniestro.NumeroSiniestro);
            sb.AppendLine("Carátula: " + contexto.Siniestro.Caratula);
            sb.AppendLine("Fecha del siniestro: " + contexto.Siniestro.FechaSiniestro.Value.ToShortDateString());
            sb.AppendLine("Lugar del siniestro: " + contexto.Siniestro.LugarSiniestro);
            sb.AppendLine();

            sb.AppendLine("PARTES INTERVINIENTES");
            sb.AppendLine("--------------------------------------");

            sb.AppendLine("Requirente/s:");
            foreach (EEIntegranteParte requirente in requirentes)
            {
                sb.AppendLine("- " + requirente.NombreRazonSocial + " | CUIT: " + requirente.CUIT);
            }

            sb.AppendLine();
            sb.AppendLine("Letrado requirente: " + letradoRequirente.NombreRazonSocial + " | CUIT: " + letradoRequirente.CUIT);
            sb.AppendLine("Mediador: " + mediador.NombreRazonSocial + " | CUIT: " + mediador.CUIT);
            sb.AppendLine("Letrado compañía: " + letradoCompania.NombreRazonSocial + " | CUIT: " + letradoCompania.CUIT);
            sb.AppendLine();

            sb.AppendLine("VEHÍCULOS / BIENES INVOLUCRADOS");
            sb.AppendLine("--------------------------------------");

            if (contexto.Vehiculos.Count == 0)
            {
                sb.AppendLine("No se registraron vehículos para este siniestro.");
            }
            else
            {
                foreach (EEVehiculo vehiculo in contexto.Vehiculos)
                {
                    sb.AppendLine("- " + vehiculo.Marca + " " + vehiculo.Modelo + " | Dominio: " + vehiculo.Dominio);
                }
            }

            sb.AppendLine();
            sb.AppendLine("CLÁUSULA DE CAPITAL");
            sb.AppendLine("--------------------------------------");
            sb.AppendLine("La compañía ofrece abonar al requirente la suma de " + FormatearMonto(capital.Monto.Value) + ",");
            sb.AppendLine("en concepto de pago único, total y definitivo por el siniestro indicado.");
            sb.AppendLine("El pago se realizará mediante transferencia bancaria al CBU informado: " + capital.CBU + ".");
            sb.AppendLine();

            sb.AppendLine("CLÁUSULA DE HONORARIOS");
            sb.AppendLine("--------------------------------------");
            AgregarHonorario(sb, "Mediador", mediador);
            AgregarHonorario(sb, "Letrado requirente", letradoRequirente);
            AgregarHonorario(sb, "Letrado compañía", letradoCompania);

            sb.AppendLine();
            sb.AppendLine("Este texto es una vista previa generada a partir de los datos cargados en el sistema.");

            return sb.ToString();
        }

        private void AgregarHonorario(StringBuilder sb, string concepto, EEIntegranteParte integrante)
        {
            if (integrante.Monto.HasValue)
            {
                sb.AppendLine(concepto + ": " + integrante.NombreRazonSocial + " - " + FormatearMonto(integrante.Monto.Value));
            }
            else
            {
                sb.AppendLine(concepto + ": " + integrante.NombreRazonSocial + " - monto no informado.");
            }
        }

        private string FormatearMonto(decimal monto)
        {
            return "$" + monto.ToString("N2");
        }
    }
}