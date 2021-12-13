using BlazorCurso.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCurso.Repositorio
{
    public class CursosRepositorio : ICursosRepositorio
    {
        private string ConnectionString;

        public CursosRepositorio(String connectionString)
        {
            ConnectionString = connectionString;
        }

        private SqlConnection conn()
        {
            return new SqlConnection(ConnectionString);
        }
        public async Task<bool> createCurso(Curso curso)
        {
            Boolean createCurso = false;
            SqlConnection sqlConn = conn();
            SqlCommand Comm = null;
            try
            {
                sqlConn.Open();
                Comm = sqlConn.CreateCommand();
                Comm.CommandText = "dbo.createCurso";
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.Parameters.Add("@Nombre", SqlDbType.VarChar, 500).Value = curso.Nombre;
                Comm.Parameters.Add("@Descripcion", SqlDbType.VarChar, 1000).Value = curso.Descripcion;
                Comm.Parameters.Add("@Profesor", SqlDbType.VarChar, 500).Value = curso.Profesor;
                Comm.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = curso.Email;
                Comm.Parameters.Add("@Precio", SqlDbType.Int).Value = curso.Precio;
                Comm.Parameters.Add("@Fecha_Ingreso", SqlDbType.DateTime).Value = DateTime.Now;
                Comm.Parameters.Add("@Fecha_Update", SqlDbType.DateTime).Value = DateTime.Now;


                if (curso.Nombre != null && curso.Descripcion != null && curso.Profesor != null && 
                    curso.Email != null && curso.Precio > 0)
                    await Comm.ExecuteNonQueryAsync();

                createCurso = true;

            }
            catch (SqlException ex)
            {
                throw new Exception("Error guardando el curso " + ex.Message);
            }
            finally
            {
                Comm.Dispose();
                sqlConn.Close();
                sqlConn.Dispose();
            }

            return createCurso;
        }

        public async Task<IEnumerable<Curso>> getAllCursos()
        {
            List<Curso> lista = new List<Curso>();
            SqlConnection sqlConn = conn();
            SqlCommand Comm = null;
            try
            {
                sqlConn.Open();
                Comm = sqlConn.CreateCommand();
                Comm.CommandText = "dbo.getAllCursos";
                Comm.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = await Comm.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Curso curso = new Curso();
                    curso.Id = Convert.ToInt32(reader["Id"]);
                    curso.Nombre = reader["Nombre"].ToString();
                    curso.Descripcion = reader["Descripcion"].ToString();
                    curso.Profesor = reader["Profesor"].ToString();
                    curso.Email = reader["Email"].ToString();
                    curso.Precio = Convert.ToInt32(reader["Precio"]);
                    curso.Fecha_Ingreso = Convert.ToDateTime(reader["Fecha_Ingreso"]);
                    curso.Fecha_Update = Convert.ToDateTime(reader["Fecha_Update"]);
                    lista.Add(curso);
                }
                reader.Close();

            }
            catch (SqlException ex)
            {
                throw new Exception("Error cargando los datos de nuestros cursos " + ex.Message);
            }
            finally
            {

                Comm.Dispose();
                sqlConn.Close();
                sqlConn.Dispose();
            }

            return lista;
        }

        public async Task<Curso> getCurso(int id)
        {
            Curso curso = new Curso();
            SqlConnection sqlConn = conn();
            SqlCommand Comm = null;
            try
            {
                sqlConn.Open();
                Comm = sqlConn.CreateCommand();
                Comm.CommandText = "dbo.getCurso";
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader reader = await Comm.ExecuteReaderAsync();
                if (reader.Read())
                {
                    curso.Id = Convert.ToInt32(reader["Id"]);
                    curso.Nombre = reader["Nombre"].ToString();
                    curso.Descripcion = reader["Descripcion"].ToString();
                    curso.Profesor = reader["Profesor"].ToString();
                    curso.Email = reader["Email"].ToString();
                    curso.Precio = Convert.ToInt32(reader["Precio"]);

                }
                reader.Close();

            }
            catch (SqlException ex)
            {
                throw new Exception("Error cargando los datos del curso " + ex.Message);
            }
            finally
            {

                Comm.Dispose();
                sqlConn.Close();
                sqlConn.Dispose();
            }

            return curso;
        }

        public async Task<bool> setCurso(Curso curso)
        {
            Boolean updateCurso = false;
            SqlConnection sqlConn = conn();
            SqlCommand Comm = null;
            try
            {
                sqlConn.Open();
                Comm = sqlConn.CreateCommand();
                Comm.CommandText = "dbo.setCurso";
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.Parameters.Add("@Id", SqlDbType.Int).Value = curso.Id;
                Comm.Parameters.Add("@Nombre", SqlDbType.VarChar, 500).Value = curso.Nombre;
                Comm.Parameters.Add("@Descripcion", SqlDbType.VarChar, 1000).Value = curso.Descripcion;
                Comm.Parameters.Add("@Profesor", SqlDbType.VarChar, 500).Value = curso.Profesor;
                Comm.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = curso.Email;
                Comm.Parameters.Add("@Precio", SqlDbType.Int).Value = curso.Precio;
                Comm.Parameters.Add("@Fecha_Update", SqlDbType.DateTime).Value = DateTime.Now;


                if (curso.Nombre != null && curso.Descripcion != null && curso.Profesor != null &&
                     curso.Email != null && curso.Precio > 0)
                    await Comm.ExecuteNonQueryAsync();

                updateCurso = true;

            }
            catch (SqlException ex)
            {
                throw new Exception("Error guardando los datos de nuestro curso " + ex.Message);
            }
            finally
            {
                Comm.Dispose();
                sqlConn.Close();
                sqlConn.Dispose();
            }

            return updateCurso;
        }

        public async Task<bool> delCurso(int id)
        {
            Boolean deleteCurso = false;
            SqlConnection sqlConn = conn();
            SqlCommand Comm = null;
            try
            {
                sqlConn.Open();
                Comm = sqlConn.CreateCommand();
                Comm.CommandText = "dbo.delCurso";
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                if (id>0)
                    await Comm.ExecuteNonQueryAsync();

                deleteCurso = true;

            }
            catch (SqlException ex)
            {
                throw new Exception("Error borrando nuestro curso " + ex.Message);
            }
            finally
            {
                Comm.Dispose();
                sqlConn.Close();
                sqlConn.Dispose();
            }

            return deleteCurso;
        }

        public async Task<IEnumerable<Curso>> getCursosSearch(string search)
        {
            List<Curso> lista = new List<Curso>();
            SqlConnection sqlConn = conn();
            SqlCommand Comm = null;
            try
            {
                sqlConn.Open();
                Comm = sqlConn.CreateCommand();
                Comm.CommandText = "dbo.getCursosSearch";
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.Parameters.Add("@search", SqlDbType.VarChar, 500).Value = search;
                SqlDataReader reader = await Comm.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Curso curso = new Curso();
                    curso.Id = Convert.ToInt32(reader["Id"]);
                    curso.Nombre = reader["Nombre"].ToString();
                    curso.Descripcion = reader["Descripcion"].ToString();
                    curso.Profesor = reader["Profesor"].ToString();
                    curso.Email = reader["Email"].ToString();
                    curso.Precio = Convert.ToInt32(reader["Precio"]);
                    curso.Fecha_Ingreso = Convert.ToDateTime(reader["Fecha_Ingreso"]);
                    curso.Fecha_Update = Convert.ToDateTime(reader["Fecha_Update"]);
                    lista.Add(curso);
                }
                reader.Close();

            }
            catch (SqlException ex)
            {
                throw new Exception("Error cargando los datos de nuestros cursos " + ex.Message);
            }
            finally
            {

                Comm.Dispose();
                sqlConn.Close();
                sqlConn.Dispose();
            }

            return lista;
        }

    }

}
