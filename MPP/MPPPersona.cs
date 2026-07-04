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
    public class MPPPersona //[NBL005]
    {
        public bool Crear(EEPersona persona)
        {
            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();

            parametros.Add("@NombreRazonSocial", persona.NombreRazonSocial);
            parametros.Add("@CUIT", string.IsNullOrWhiteSpace(persona.CUIT) ? (object)DBNull.Value : persona.CUIT);
            parametros.Add("@CBU", string.IsNullOrWhiteSpace(persona.CBU) ? (object)DBNull.Value : persona.CBU);
            parametros.Add("@Observaciones", string.IsNullOrWhiteSpace(persona.Observaciones) ? (object)DBNull.Value : persona.Observaciones);

            return acceso.Escribir("s_Persona_Crear", parametros);
        }

        public bool Modificar(EEPersona persona)
        {
            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();

            parametros.Add("@IDPersona", persona.IDPersona);
            parametros.Add("@NombreRazonSocial", persona.NombreRazonSocial);
            parametros.Add("@CUIT", string.IsNullOrWhiteSpace(persona.CUIT) ? (object)DBNull.Value : persona.CUIT);
            parametros.Add("@CBU", string.IsNullOrWhiteSpace(persona.CBU) ? (object)DBNull.Value : persona.CBU);
            parametros.Add("@Observaciones", string.IsNullOrWhiteSpace(persona.Observaciones) ? (object)DBNull.Value : persona.Observaciones);
            parametros.Add("@Activo", persona.Activo);

            return acceso.Escribir("s_Persona_Modificar", parametros);
        }

        public List<EEPersona> Listar()
        {
            Acceso acceso = new Acceso();
            DataSet ds = acceso.Leer("s_Persona_Listar", null);

            List<EEPersona> lista = new List<EEPersona>();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    lista.Add(MapearPersona(item));
                }
            }

            return lista;
        }

        public List<EEPersona> ListarActivas()
        {
            Acceso acceso = new Acceso();
            DataSet ds = acceso.Leer("s_Persona_ListarActivas", null);

            List<EEPersona> lista = new List<EEPersona>();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    lista.Add(MapearPersona(item));
                }
            }

            return lista;
        }

        private EEPersona MapearPersona(DataRow item)
        {
            EEPersona persona = new EEPersona();

            persona.IDPersona = Convert.ToInt32(item["IDPersona"]);
            persona.NombreRazonSocial = item["NombreRazonSocial"].ToString();
            persona.CUIT = item["CUIT"].ToString();
            persona.CBU = item["CBU"].ToString();
            persona.Observaciones = item["Observaciones"].ToString();
            persona.Activo = Convert.ToBoolean(item["Activo"]);

            return persona;
        }
    }
}