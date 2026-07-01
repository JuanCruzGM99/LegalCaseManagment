using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Acceso
    {
        //[NBL001] INICIO - Se cambia la cadena de conexion para que funcione en la notebook
        private string CadenaC = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BDHardwareFinal;Data Source=.\SQLEXPRESS";
        public SqlConnection connection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BDHardwareFinal;Data Source=.\SQLEXPRESS");
        //private string CadenaC = @"Data Source=050LAB3-18;Initial Catalog=BDHardwareFinal;Integrated Security=True";
        //private string CadenaC = @"Data Source=DESKTOP-NSUHLDS\SQLEXPRESS;Initial Catalog=BDHardwareFinal;Integrated Security=True";
        //public SqlConnection connection = new SqlConnection(@"Data Source=050LAB3-18;Initial Catalog=BDHardwareFinal;Integrated Security=True");
        //public SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-NSUHLDS\SQLEXPRESS;Initial Catalog=BDHardwareFinal;Integrated Security=True");
        //[NBL001] FIN

        private SqlTransaction Trans;
        private SqlCommand cmd;


        public DataSet Leer(string consulta, Hashtable hdatos)
        {
            try
            {
                DataSet ds = new DataSet();
                cmd = new SqlCommand();

                cmd.Connection = connection;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.StoredProcedure;
                if (hdatos != null)
                {
                    foreach (string NombreParametro in hdatos.Keys)
                    {
                        cmd.Parameters.AddWithValue(NombreParametro, hdatos[NombreParametro]);
                    }
                }

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(ds);
                return ds;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        //private SqlCommand CrearComando(string nombre, List<SqlParameter> pars)
        //{

        //    SqlCommand cmd = new SqlCommand(nombre, connection);
        //    if (Trans != null)
        //    {

        //        cmd.Transaction = Trans;
        //    }

        //    if (pars != null && pars.Count > 0)
        //    {

        //        cmd.Parameters.AddRange(pars.ToArray());
        //    }

        //    cmd.CommandType = CommandType.StoredProcedure;
        //    return cmd;
        //}
        public bool OpenCnn()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.ConnectionString = CadenaC;
                connection.Open();
            }
            return true;
        }
        public SqlParameter CrearParametro(string nombre, int valor)
        {

            SqlParameter parametro = new SqlParameter(nombre, valor);
            parametro.DbType = DbType.String;
            return parametro;
        }

        public bool Escribir(string consulta, Hashtable hdatos)
        {

            if (connection.State == ConnectionState.Closed)
            {
                connection.ConnectionString = CadenaC;
                connection.Open();
            }

            try
            {
                Trans = connection.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = Trans;


                if ((hdatos != null))
                {
                    foreach (string NombreParametro in hdatos.Keys)
                    {
                        cmd.Parameters.AddWithValue(NombreParametro, hdatos[NombreParametro]);
                    }
                }

                int respuesta = cmd.ExecuteNonQuery();
                Trans.Commit();
                return true;

            }
            catch (Exception ex)
            {
                Trans.Rollback();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        //public DataTable LeerTabla(string consulta, Hashtable hdatos)
        //{

        //    DataTable Dt = new DataTable();
        //    cmd = new SqlCommand();

        //    cmd.Connection = connection;
        //    cmd.CommandText = consulta;
        //    cmd.CommandType = CommandType.StoredProcedure;


        //    if ((hdatos != null))
        //    {
        //        foreach (string dato in hdatos.Keys)
        //        {
        //            cmd.Parameters.AddWithValue(dato, hdatos.Values);
        //        }
        //    }

        //    SqlDataAdapter Adaptador = new SqlDataAdapter(cmd);
        //    Adaptador.Fill(Dt);
        //    return Dt;


        //}
    }
}
