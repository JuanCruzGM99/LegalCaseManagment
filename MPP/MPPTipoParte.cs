using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BE;
using DAL;

namespace MPP
{
    public class MPPTipoParte //[NBL005]
    {
        public List<EETipoParte> Listar()
        {
            Acceso acceso = new Acceso();
            DataSet ds = acceso.Leer("s_TipoParte_Listar", null);

            List<EETipoParte> lista = new List<EETipoParte>();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    EETipoParte tipoParte = new EETipoParte();

                    tipoParte.IDTipoParte = Convert.ToInt32(item["IDTipoParte"]);
                    tipoParte.Nombre = item["Nombre"].ToString();
                    tipoParte.Orden = Convert.ToInt32(item["Orden"]);

                    lista.Add(tipoParte);
                }
            }

            return lista;
        }
    }
}