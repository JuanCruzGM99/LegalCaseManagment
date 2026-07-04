using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BLL //[NBL006]
{
    public class FormularioPagoLegal : DocumentoLegal
    {
        public override string NombreDocumento
        {
            get { return "Formulario de solicitud de pago"; }
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
                errores.Add("El formulario requiere número de siniestro.");

            if (string.IsNullOrWhiteSpace(contexto.Siniestro.Caratula))
                errores.Add("El formulario requiere carátula.");

            if (string.IsNullOrWhiteSpace(contexto.Siniestro.AnalistaInterno))
                errores.Add("El formulario requiere analista interno.");

            List<LineaPagoDocumento> lineas = ObtenerLineasPago(contexto);

            if (lineas.Count == 0)
                errores.Add("Debe existir al menos un integrante con monto para generar líneas de pago.");

            foreach (LineaPagoDocumento linea in lineas)
            {
                if (string.IsNullOrWhiteSpace(linea.Beneficiario))
                    errores.Add("Una línea de pago no tiene beneficiario.");

                if (string.IsNullOrWhiteSpace(linea.CUIT))
                    errores.Add("El beneficiario " + linea.Beneficiario + " no tiene CUIT.");

                if (string.IsNullOrWhiteSpace(linea.CBU))
                    errores.Add("El beneficiario " + linea.Beneficiario + " no tiene CBU.");

                if (linea.Importe <= 0)
                    errores.Add("El beneficiario " + linea.Beneficiario + " tiene importe inválido.");
            }

            return errores;
        }

        public override string GenerarVistaPrevia(ContextoDocumentoLegal contexto)
        {
            StringBuilder sb = new StringBuilder();

            List<LineaPagoDocumento> lineas = ObtenerLineasPago(contexto);
            decimal total = lineas.Sum(l => l.Importe);

            sb.AppendLine("FORMULARIO DE SOLICITUD DE PAGOS - VISTA PREVIA");
            sb.AppendLine("================================================");
            sb.AppendLine();

            sb.AppendLine("Analista: " + contexto.Siniestro.AnalistaInterno);
            sb.AppendLine("Siniestro N°: " + contexto.Siniestro.NumeroSiniestro);
            sb.AppendLine("Carátula mediación: " + contexto.Siniestro.Caratula);
            sb.AppendLine();

            sb.AppendLine("LÍNEAS DE PAGO");
            sb.AppendLine("------------------------------------------------");

            foreach (LineaPagoDocumento linea in lineas)
            {
                sb.AppendLine("Concepto: " + linea.Concepto);
                sb.AppendLine("Beneficiario: " + linea.Beneficiario);
                sb.AppendLine("CUIT/CUIL: " + linea.CUIT);
                sb.AppendLine("Importe: $" + linea.Importe.ToString("N2"));
                sb.AppendLine("Fecha / plazo de pago: " + linea.FechaPago);
                sb.AppendLine("Forma de pago: " + linea.FormaPago);
                sb.AppendLine("CBU: " + linea.CBU);
                sb.AppendLine();
            }

            sb.AppendLine("TOTAL: $" + total.ToString("N2"));
            sb.AppendLine();
            sb.AppendLine("Este texto representa la estructura del formulario de pago generado desde el sistema.");

            return sb.ToString();
        }

        private List<LineaPagoDocumento> ObtenerLineasPago(ContextoDocumentoLegal contexto)
        {
            List<LineaPagoDocumento> lineas = new List<LineaPagoDocumento>();

            AgregarLineasPorTipoParte(
                lineas,
                contexto,
                TiposParteDocumento.Requirente,
                "CAPITAL (requirente)"
            );

            AgregarLineasPorTipoParte(
                lineas,
                contexto,
                TiposParteDocumento.LetradoRequirente,
                "Honorarios Letrado Requirente"
            );

            AgregarLineasPorTipoParte(
                lineas,
                contexto,
                TiposParteDocumento.Mediador,
                "Honorarios Mediador"
            );

            AgregarLineasPorTipoParte(
                lineas,
                contexto,
                TiposParteDocumento.LetradoCompania,
                "Honorarios Letrado Compañia"
            );

            return lineas;
        }

        private void AgregarLineasPorTipoParte(
            List<LineaPagoDocumento> lineas,
            ContextoDocumentoLegal contexto,
            string tipoParte,
            string concepto
        )
        {
            List<EEIntegranteParte> integrantes = contexto
                .ObtenerIntegrantesPorTipoParte(tipoParte)
                .Where(i => i.Monto.HasValue)
                .ToList();

            foreach (EEIntegranteParte integrante in integrantes)
            {
                LineaPagoDocumento linea = new LineaPagoDocumento();

                linea.Concepto = concepto;
                linea.Beneficiario = integrante.NombreRazonSocial;
                linea.CUIT = integrante.CUIT;
                linea.Importe = integrante.Monto.Value;
                linea.FechaPago = string.IsNullOrWhiteSpace(integrante.PlazoPago) ? "-" : integrante.PlazoPago;
                linea.FormaPago = "Transferencia";
                linea.CBU = integrante.CBU;

                lineas.Add(linea);
            }
        }
    }
}