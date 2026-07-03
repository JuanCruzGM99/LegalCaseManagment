using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using BE;
using DAL;

namespace MPP //[NBL004] Se crea clase MPPSiniestro
{
    public class MPPSiniestro
    {
        public bool Crear(EESiniestro siniestro)
        {
            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();

            parametros.Add("@NumeroSiniestro", siniestro.NumeroSiniestro);
            parametros.Add("@Caratula", siniestro.Caratula);
            parametros.Add("@AnalistaInterno", siniestro.AnalistaInterno);
            parametros.Add("@FechaSiniestro", siniestro.FechaSiniestro.HasValue ? (object)siniestro.FechaSiniestro.Value.Date : DBNull.Value);
            parametros.Add("@LugarSiniestro", siniestro.LugarSiniestro);
            parametros.Add("@Estado", siniestro.Estado);
            parametros.Add("@Observaciones", siniestro.Observaciones);

            return acceso.Escribir("s_Siniestro_Crear", parametros);
        }

        public bool Modificar(EESiniestro siniestro, int idUser)
        {
            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();

            parametros.Add("@IDSiniestro", siniestro.IDSiniestro);
            parametros.Add("@NumeroSiniestro", siniestro.NumeroSiniestro);
            parametros.Add("@Caratula", siniestro.Caratula);
            parametros.Add("@AnalistaInterno", siniestro.AnalistaInterno);
            parametros.Add("@FechaSiniestro", siniestro.FechaSiniestro.HasValue ? (object)siniestro.FechaSiniestro.Value.Date : DBNull.Value);
            parametros.Add("@LugarSiniestro", siniestro.LugarSiniestro);
            parametros.Add("@Estado", siniestro.Estado);
            parametros.Add("@Observaciones", siniestro.Observaciones);
            parametros.Add("@IDUser", idUser);

            return acceso.Escribir("s_Siniestro_Modificar", parametros);
        }

        public List<EESiniestro> Listar()
        {
            Acceso acceso = new Acceso();
            DataSet ds = acceso.Leer("s_Siniestro_Listar", null);

            List<EESiniestro> lista = new List<EESiniestro>();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    lista.Add(MapearSiniestro(item));
                }
            }

            return lista;
        }

        public EESiniestro ObtenerPorId(int idSiniestro)
        {
            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();

            parametros.Add("@IDSiniestro", idSiniestro);

            DataSet ds = acceso.Leer("s_Siniestro_ObtenerPorId", parametros);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return MapearSiniestro(ds.Tables[0].Rows[0]);
            }

            return null;
        }

        public List<EEControlCambioSiniestro> ListarCambiosPorSiniestro(int idSiniestro)
        {
            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();

            parametros.Add("@IDSiniestro", idSiniestro);

            DataSet ds = acceso.Leer("s_ControlCambioSiniestro_ListarPorSiniestro", parametros);

            List<EEControlCambioSiniestro> lista = new List<EEControlCambioSiniestro>();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    EEControlCambioSiniestro cambio = new EEControlCambioSiniestro();

                    cambio.IDControlCambio = Convert.ToInt32(item["IDControlCambio"]);
                    cambio.IDSiniestro = Convert.ToInt32(item["IDSiniestro"]);
                    cambio.IDHistorialSiniestro = item["IDHistorialSiniestro"] == DBNull.Value ? (int?)null : Convert.ToInt32(item["IDHistorialSiniestro"]);
                    cambio.Usuario = item["Usuario"].ToString();
                    cambio.Campo = item["Campo"].ToString();
                    cambio.ValorAnterior = item["ValorAnterior"].ToString();
                    cambio.ValorNuevo = item["ValorNuevo"].ToString();
                    cambio.Fecha = Convert.ToDateTime(item["Fecha"]);
                    cambio.Hora = (TimeSpan)item["Hora"];

                    lista.Add(cambio);
                }
            }

            return lista;
        }

        public List<EEHistorialSiniestro> ListarHistorialPorSiniestro(int idSiniestro)
        {
            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();

            parametros.Add("@IDSiniestro", idSiniestro);

            DataSet ds = acceso.Leer("s_HistorialSiniestro_ListarPorSiniestro", parametros);

            List<EEHistorialSiniestro> lista = new List<EEHistorialSiniestro>();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    EEHistorialSiniestro historial = new EEHistorialSiniestro();

                    historial.IDHistorialSiniestro = Convert.ToInt32(item["IDHistorialSiniestro"]);
                    historial.IDSiniestro = Convert.ToInt32(item["IDSiniestro"]);
                    historial.Usuario = item["Usuario"].ToString();
                    historial.NumeroSiniestro = item["NumeroSiniestro"].ToString();
                    historial.Caratula = item["Caratula"].ToString();
                    historial.AnalistaInterno = item["AnalistaInterno"].ToString();
                    historial.FechaSiniestro = item["FechaSiniestro"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(item["FechaSiniestro"]);
                    historial.LugarSiniestro = item["LugarSiniestro"].ToString();
                    historial.Estado = item["Estado"].ToString();
                    historial.Observaciones = item["Observaciones"].ToString();
                    historial.Fecha = Convert.ToDateTime(item["Fecha"]);
                    historial.Hora = (TimeSpan)item["Hora"];
                    historial.Accion = item["Accion"].ToString();

                    lista.Add(historial);
                }
            }

            return lista;
        }

        public bool RestaurarDesdeHistorial(int idHistorialSiniestro, int idUser)
        {
            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();

            parametros.Add("@IDHistorialSiniestro", idHistorialSiniestro);
            parametros.Add("@IDUser", idUser);

            return acceso.Escribir("s_Siniestro_RestaurarDesdeHistorial", parametros);
        }

        private EESiniestro MapearSiniestro(DataRow item)
        {
            EESiniestro siniestro = new EESiniestro();

            siniestro.IDSiniestro = Convert.ToInt32(item["IDSiniestro"]);
            siniestro.NumeroSiniestro = item["NumeroSiniestro"].ToString();
            siniestro.Caratula = item["Caratula"].ToString();
            siniestro.AnalistaInterno = item["AnalistaInterno"].ToString();
            siniestro.FechaSiniestro = item["FechaSiniestro"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(item["FechaSiniestro"]);
            siniestro.LugarSiniestro = item["LugarSiniestro"].ToString();
            siniestro.Estado = item["Estado"].ToString();
            siniestro.Observaciones = item["Observaciones"].ToString();

            return siniestro;
        }
    }
}
