using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL //[NBL006]
{
    public abstract class DocumentoLegal
    {
        public abstract string NombreDocumento { get; }

        public abstract List<string> Validar(ContextoDocumentoLegal contexto);

        public abstract string GenerarVistaPrevia(ContextoDocumentoLegal contexto);
    }
}