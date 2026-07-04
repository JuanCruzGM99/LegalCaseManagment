using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using BE;
using DAL;

namespace MPP
{
    public class MPPIntegranteParte //[NBL005]
    {
        public bool Crear(EEIntegranteParte integranteParte)
        {
            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();

            parametros.Add("@IDParte", integranteParte.IDParte);
            parametros.Add("@IDPersona", integranteParte.IDPersona);
            parametros.Add("@Monto", integranteParte.Monto.HasValue ? (object)integranteParte.Monto.Value : DBNull.Value);
            parametros.Add("@PlazoPago", string.IsNullOrWhiteSpace(integranteParte.PlazoPago) ? (object)DBNull.Value : integranteParte.PlazoPago);
            parametros.Add("@EsPrincipal", integranteParte.EsPrincipal);
            parametros.Add("@Observaciones", string.IsNullOrWhiteSpace(integranteParte.Observaciones) ? (object)DBNull.Value : integranteParte.Observaciones);

            return acceso.Escribir("s_IntegranteParte_Crear", parametros);
        }

        public List<EEIntegranteParte> ListarPorParte(int idParte)
        {
            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();

            parametros.Add("@IDParte", idParte);

            DataSet ds = acceso.Leer("s_IntegranteParte_ListarPorParte", parametros);

            List<EEIntegranteParte> lista = new List<EEIntegranteParte>();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    EEIntegranteParte integranteParte = new EEIntegranteParte();

                    integranteParte.IDIntegranteParte = Convert.ToInt32(item["IDIntegranteParte"]);
                    integranteParte.IDParte = Convert.ToInt32(item["IDParte"]);
                    integranteParte.IDPersona = Convert.ToInt32(item["IDPersona"]);
                    integranteParte.NombreRazonSocial = item["NombreRazonSocial"].ToString();
                    integranteParte.CUIT = item["CUIT"].ToString();
                    integranteParte.CBU = item["CBU"].ToString();
                    integranteParte.Monto = item["Monto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(item["Monto"]);
                    integranteParte.PlazoPago = item["PlazoPago"].ToString();
                    integranteParte.EsPrincipal = Convert.ToBoolean(item["EsPrincipal"]);
                    integranteParte.Observaciones = item["Observaciones"].ToString();

                    lista.Add(integranteParte);
                }
            }

            return lista;
        }
    }
}