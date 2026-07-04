using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Interfaces;
using Services.Composite;

namespace DAL
{
    public class PatenteDAL : ICrud<IPatente>
    {
        public IPatente GetById(Guid id)
        {
            return GetAll().FirstOrDefault(p => p.Id.Equals(id));
        }

        public IPatente GetById(int id)
        {
            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();
            parametros.Add("@IDPatente", id);

            DataSet ds = acceso.Leer("s_Patente_ObtenerPorId", parametros);

            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;

            return MapearPatente(ds.Tables[0].Rows[0]);
        }

        public IList<IPatente> GetAll()
        {
            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();
            parametros.Add("@SoloActivos", true);

            DataSet ds = acceso.Leer("s_Patente_Listar", parametros);
            List<IPatente> patentes = new List<IPatente>();

            if (ds.Tables.Count == 0)
                return patentes;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                patentes.Add(MapearPatente(row));
            }

            return patentes;
        }

        public void Save(IPatente entity)
        {
            Patente patente = entity as Patente;
            if (patente == null)
                throw new ArgumentException("La entidad debe ser de tipo Patente.");

            if (String.IsNullOrWhiteSpace(patente.Codigo))
                patente.Codigo = patente.Nombre.Replace(" ", "_").ToUpper();

            Hashtable parametros = new Hashtable();
            parametros.Add("@Nombre", patente.Nombre);
            parametros.Add("@Codigo", patente.Codigo);
            parametros.Add("@TipoPermiso", patente.Tipo.HasValue ? (object)((int)patente.Tipo.Value) : DBNull.Value);

            Acceso acceso = new Acceso();

            if (patente.ID <= 0)
            {
                DataSet ds = acceso.Leer("s_Patente_Crear", parametros);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    patente.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["IDPatente"]);
            }
            else
            {
                parametros.Add("@IDPatente", patente.ID);
                parametros.Add("@Activo", true);
                acceso.Escribir("s_Patente_Modificar", parametros);
            }
        }

        public void Delete(IPatente entity)
        {
            Patente patente = entity as Patente;
            if (patente == null || patente.ID <= 0)
                return;

            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();
            parametros.Add("@IDPatente", patente.ID);
            acceso.Escribir("s_Patente_Eliminar", parametros);
        }

        public static Patente MapearPatente(DataRow row)
        {
            Patente patente = new Patente();

            if (row.Table.Columns.Contains("IDPatente"))
                patente.ID = Convert.ToInt32(row["IDPatente"]);
            else if (row.Table.Columns.Contains("IDHijo"))
                patente.ID = Convert.ToInt32(row["IDHijo"]);
            else if (row.Table.Columns.Contains("IDComponente"))
                patente.ID = Convert.ToInt32(row["IDComponente"]);

            if (row.Table.Columns.Contains("Id") && row["Id"] != DBNull.Value)
                patente.Id = (Guid)row["Id"];
            else if (row.Table.Columns.Contains("GuidHijo") && row["GuidHijo"] != DBNull.Value)
                patente.Id = (Guid)row["GuidHijo"];
            else if (row.Table.Columns.Contains("GuidComponente") && row["GuidComponente"] != DBNull.Value)
                patente.Id = (Guid)row["GuidComponente"];

            if (row.Table.Columns.Contains("Nombre") && row["Nombre"] != DBNull.Value)
                patente.Nombre = row["Nombre"].ToString();
            else if (row.Table.Columns.Contains("NombreHijo") && row["NombreHijo"] != DBNull.Value)
                patente.Nombre = row["NombreHijo"].ToString();

            if (row.Table.Columns.Contains("Codigo") && row["Codigo"] != DBNull.Value)
                patente.Codigo = row["Codigo"].ToString();

            if (row.Table.Columns.Contains("TipoPermiso") && row["TipoPermiso"] != DBNull.Value)
                patente.Tipo = (TipoPermiso)Convert.ToInt32(row["TipoPermiso"]);

            return patente;
        }
    }
}
