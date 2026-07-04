using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL //[NBL006]
{
    public class CreadorFormularioPagoLegal : CreadorDocumentoLegal
    {
        public override DocumentoLegal CrearDocumento()
        {
            return new FormularioPagoLegal();
        }
    }
}
