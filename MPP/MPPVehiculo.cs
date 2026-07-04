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
    public class MPPVehiculo //[NBL005]
    {
        public bool Crear(EEVehiculo vehiculo)
        {
            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();

            parametros.Add("@IDSiniestro", vehiculo.IDSiniestro);
            parametros.Add("@Marca", vehiculo.Marca);
            parametros.Add("@Modelo", string.IsNullOrWhiteSpace(vehiculo.Modelo) ? (object)DBNull.Value : vehiculo.Modelo);
            parametros.Add("@Dominio", vehiculo.Dominio);
            parametros.Add("@Observaciones", string.IsNullOrWhiteSpace(vehiculo.Observaciones) ? (object)DBNull.Value : vehiculo.Observaciones);

            return acceso.Escribir("s_Vehiculo_Crear", parametros);
        }

        public List<EEVehiculo> ListarPorSiniestro(int idSiniestro)
        {
            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();

            parametros.Add("@IDSiniestro", idSiniestro);

            DataSet ds = acceso.Leer("s_Vehiculo_ListarPorSiniestro", parametros);

            List<EEVehiculo> lista = new List<EEVehiculo>();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    EEVehiculo vehiculo = new EEVehiculo();

                    vehiculo.IDVehiculo = Convert.ToInt32(item["IDVehiculo"]);
                    vehiculo.IDSiniestro = Convert.ToInt32(item["IDSiniestro"]);
                    vehiculo.Marca = item["Marca"].ToString();
                    vehiculo.Modelo = item["Modelo"].ToString();
                    vehiculo.Dominio = item["Dominio"].ToString();
                    vehiculo.Observaciones = item["Observaciones"].ToString();

                    lista.Add(vehiculo);
                }
            }

            return lista;
        }
    }
}
