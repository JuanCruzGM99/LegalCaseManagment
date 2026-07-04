using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL //[NBL006]
{
    public abstract class CreadorDocumentoLegal
    {
        public abstract DocumentoLegal CrearDocumento();

        public string GenerarDocumento(ContextoDocumentoLegal contexto)
        {
            DocumentoLegal documento = CrearDocumento();

            List<string> errores = documento.Validar(contexto);

            if (errores.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("No se puede generar el documento: " + documento.NombreDocumento);
                sb.AppendLine();
                sb.AppendLine("Datos faltantes o inconsistentes:");

                foreach (string error in errores)
                {
                    sb.AppendLine("- " + error);
                }

                return sb.ToString();
            }

            return documento.GenerarVistaPrevia(contexto);
        }
    }
}