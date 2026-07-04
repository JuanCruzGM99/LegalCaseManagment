using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Services.Composite;

namespace DAL
{
    public class FamiliaDAL : ICrud<IFamilia>
    {
        public IFamilia GetById(Guid id)
        {
            return GetAll().FirstOrDefault(f => f.Id.Equals(id));
        }

        public IFamilia GetById(int id)
        {
            return GetAll().FirstOrDefault(f => ((Familia)f).ID == id);
        }

        public IList<IFamilia> GetAll()
        {
            Dictionary<int, Familia> familias = ObtenerFamiliasConRelaciones();
            return familias.Values.Cast<IFamilia>().ToList();
        }

        public IList<IFamilia> ListarPorUsuario(int idUsuario)
        {
            Dictionary<int, Familia> familias = ObtenerFamiliasConRelaciones();

            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();
            parametros.Add("@IDUser", idUsuario);

            DataSet ds = acceso.Leer("s_UsuarioFamilia_Listar", parametros);
            List<IFamilia> resultado = new List<IFamilia>();

            if (ds.Tables.Count == 0)
                return resultado;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                int idFamilia = Convert.ToInt32(row["IDFamilia"]);
                if (familias.ContainsKey(idFamilia))
                    resultado.Add(familias[idFamilia]);
            }

            return resultado;
        }

        public void Save(IFamilia entity)
        {
            Familia familia = entity as Familia;
            if (familia == null)
                throw new ArgumentException("La entidad debe ser de tipo Familia.");

            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();
            parametros.Add("@Nombre", familia.Nombre);

            if (familia.ID <= 0)
            {
                DataSet ds = acceso.Leer("s_Familia_Crear", parametros);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    familia.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["IDFamilia"]);
            }
            else
            {
                parametros.Add("@IDFamilia", familia.ID);
                parametros.Add("@Activo", true);
                acceso.Escribir("s_Familia_Modificar", parametros);
            }

            GuardarRelaciones(familia);
        }

        public void Delete(IFamilia entity)
        {
            Familia familia = entity as Familia;
            if (familia == null || familia.ID <= 0)
                return;

            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();
            parametros.Add("@IDFamilia", familia.ID);
            acceso.Escribir("s_Familia_Eliminar", parametros);
        }

        public void AsignarFamiliaAUsuario(int idUsuario, int idFamilia)
        {
            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();
            parametros.Add("@IDUser", idUsuario);
            parametros.Add("@IDFamilia", idFamilia);
            acceso.Escribir("s_UsuarioFamilia_Asignar", parametros);
        }

        public void QuitarFamiliaAUsuario(int idUsuario, int idFamilia)
        {
            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();
            parametros.Add("@IDUser", idUsuario);
            parametros.Add("@IDFamilia", idFamilia);
            acceso.Escribir("s_UsuarioFamilia_Quitar", parametros);
        }

        private Dictionary<int, Familia> ObtenerFamiliasConRelaciones()
        {
            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();
            parametros.Add("@SoloActivos", true);

            DataSet dsFamilias = acceso.Leer("s_Familia_Listar", parametros);
            Dictionary<int, Familia> familias = new Dictionary<int, Familia>();

            if (dsFamilias.Tables.Count > 0)
            {
                foreach (DataRow row in dsFamilias.Tables[0].Rows)
                {
                    Familia familia = MapearFamilia(row);
                    familias[familia.ID] = familia;
                }
            }

            DataSet dsRelaciones = acceso.Leer("s_Familia_ListarRelaciones", null);

            if (dsRelaciones.Tables.Count > 0)
            {
                foreach (DataRow row in dsRelaciones.Tables[0].Rows)
                {
                    int idPadre = Convert.ToInt32(row["IDFamiliaPadre"]);

                    if (!familias.ContainsKey(idPadre))
                        continue;

                    string tipoHijo = row["TipoHijo"].ToString();

                    if (tipoHijo == "F")
                    {
                        int idHijo = Convert.ToInt32(row["IDHijo"]);
                        if (familias.ContainsKey(idHijo))
                            familias[idPadre].AgregarPermiso(familias[idHijo]);
                    }
                    else if (tipoHijo == "P")
                    {
                        familias[idPadre].AgregarPermiso(PatenteDAL.MapearPatente(row));
                    }
                }
            }

            return familias;
        }

        private void GuardarRelaciones(Familia familia)
        {
            foreach (IPermiso hijo in familia.ObtenerHijos())
            {
                Patente patente = hijo as Patente;
                if (patente != null)
                {
                    if (patente.ID <= 0)
                        new PatenteDAL().Save(patente);

                    AgregarPatente(familia.ID, patente.ID);
                    continue;
                }

                Familia familiaHija = hijo as Familia;
                if (familiaHija != null)
                {
                    if (familiaHija.ID <= 0)
                        Save(familiaHija);

                    AgregarFamilia(familia.ID, familiaHija.ID);
                }
            }
        }

        private void AgregarPatente(int idFamilia, int idPatente)
        {
            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();
            parametros.Add("@IDFamilia", idFamilia);
            parametros.Add("@IDPatente", idPatente);
            acceso.Escribir("s_Familia_AgregarPatente", parametros);
        }

        private void AgregarFamilia(int idFamiliaPadre, int idFamiliaHija)
        {
            Acceso acceso = new Acceso();
            Hashtable parametros = new Hashtable();
            parametros.Add("@IDFamiliaPadre", idFamiliaPadre);
            parametros.Add("@IDFamiliaHija", idFamiliaHija);
            acceso.Escribir("s_Familia_AgregarFamilia", parametros);
        }

        private Familia MapearFamilia(DataRow row)
        {
            Familia familia = new Familia();

            if (row.Table.Columns.Contains("IDFamilia"))
                familia.ID = Convert.ToInt32(row["IDFamilia"]);
            else if (row.Table.Columns.Contains("IDHijo"))
                familia.ID = Convert.ToInt32(row["IDHijo"]);
            else if (row.Table.Columns.Contains("IDComponente"))
                familia.ID = Convert.ToInt32(row["IDComponente"]);

            if (row.Table.Columns.Contains("Id") && row["Id"] != DBNull.Value)
                familia.Id = (Guid)row["Id"];
            else if (row.Table.Columns.Contains("GuidHijo") && row["GuidHijo"] != DBNull.Value)
                familia.Id = (Guid)row["GuidHijo"];
            else if (row.Table.Columns.Contains("GuidComponente") && row["GuidComponente"] != DBNull.Value)
                familia.Id = (Guid)row["GuidComponente"];

            if (row.Table.Columns.Contains("Nombre") && row["Nombre"] != DBNull.Value)
                familia.Nombre = row["Nombre"].ToString();
            else if (row.Table.Columns.Contains("NombreHijo") && row["NombreHijo"] != DBNull.Value)
                familia.Nombre = row["NombreHijo"].ToString();

            return familia;
        }
    }
}
