using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BE;
using DAL;

namespace MPP
{
    public class MPPBitacora
    {
        public List<EEBitacora> Listar(DateTime? fechaDesde, DateTime? fechaHasta, TimeSpan? horaDesde, TimeSpan? horaHasta, string actividad, string usuario)
        {
            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();

            if (fechaDesde.HasValue)
                parametros.Add("@FechaDesde", fechaDesde.Value.Date);

            if (fechaHasta.HasValue)
                parametros.Add("@FechaHasta", fechaHasta.Value.Date);

            if (horaDesde.HasValue)
                parametros.Add("@HoraDesde", horaDesde.Value);

            if (horaHasta.HasValue)
                parametros.Add("@HoraHasta", horaHasta.Value);

            if (!string.IsNullOrWhiteSpace(actividad))
                parametros.Add("@Actividad", actividad);

            if (!string.IsNullOrWhiteSpace(usuario))
                parametros.Add("@NombreUsuario", usuario);

            DataSet ds = acceso.Leer("s_Bitacora_Listar", parametros.Count > 0 ? parametros : null);

            List<EEBitacora> lista = new List<EEBitacora>();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    EEBitacora bitacora = new EEBitacora();

                    bitacora.IDBitacora = Convert.ToInt32(item["IDBitacora"]);
                    bitacora.Usuario = item["Usuario"].ToString();
                    bitacora.Actividad = item["Actividad"].ToString();
                    bitacora.Fecha = Convert.ToDateTime(item["Fecha"]);
                    bitacora.Hora = (TimeSpan)item["Hora"];

                    lista.Add(bitacora);
                }
            }

            return lista;
        }


        public bool Crear(int idUser, string actividad)
        {
            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();

            parametros.Add("@IDUser", idUser);
            parametros.Add("@Actividad", actividad);

            return acceso.Escribir("s_Bitacora_Crear", parametros);
        }
    }
}