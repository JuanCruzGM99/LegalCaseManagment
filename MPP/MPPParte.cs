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
    public class MPPParte //[NBL005]
    {
        public bool Crear(EEParte parte)
        {
            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();

            parametros.Add("@IDSiniestro", parte.IDSiniestro);
            parametros.Add("@IDTipoParte", parte.IDTipoParte);
            parametros.Add("@Observaciones", string.IsNullOrWhiteSpace(parte.Observaciones) ? (object)DBNull.Value : parte.Observaciones);

            return acceso.Escribir("s_Parte_Crear", parametros);
        }

        public List<EEParte> ListarPorSiniestro(int idSiniestro)
        {
            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();

            parametros.Add("@IDSiniestro", idSiniestro);

            DataSet ds = acceso.Leer("s_Parte_ListarPorSiniestro", parametros);

            List<EEParte> lista = new List<EEParte>();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    EEParte parte = new EEParte();

                    parte.IDParte = Convert.ToInt32(item["IDParte"]);
                    parte.IDSiniestro = Convert.ToInt32(item["IDSiniestro"]);
                    parte.IDTipoParte = Convert.ToInt32(item["IDTipoParte"]);
                    parte.TipoParte = item["TipoParte"].ToString();
                    parte.Observaciones = item["Observaciones"].ToString();

                    lista.Add(parte);
                }
            }

            return lista;
        }
    }
}
