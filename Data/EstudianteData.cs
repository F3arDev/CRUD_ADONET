using CRUD_ADONET.Models;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_ADONET.Data
{
    public class EstudianteData
    {
        /*Obtener Lista de Estudiantes*/
        public List<EstudianteModel> Listar()
        {
            var oLista = new List<EstudianteModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new("sp_listar_estudiantes", conexion);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new EstudianteModel()
                        {
                            CodEstudiante = Convert.ToInt32(dr["codEstudiante"]),
                            Nombre = dr["Nombre"].ToString(),
                            Edad = Convert.ToInt32(dr["Edad"]),
                            CodGrado = Convert.ToInt32(dr["CodGrado"]),
                        });
                    }
                };
            }
            return oLista;
        }

        /*Obtener Estudiante*/
        public EstudianteModel ObtenerEstudiante(int CodEstudiante)
        {
            var oEstudiante = new EstudianteModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new("sp_LeerEstudiantePorCodigo", conexion);
                cmd.Parameters.AddWithValue("@CodEstudiante", CodEstudiante);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oEstudiante.CodEstudiante = Convert.ToInt32(dr["codEstudiante"]);
                        oEstudiante.Nombre = dr["Nombre"].ToString();
                        oEstudiante.Edad = Convert.ToInt32(dr["Edad"]);
                        oEstudiante.CodGrado = Convert.ToInt32(dr["CodGrado"]);
                    }
                };
            }
            return oEstudiante;
        }/*Insertar Estudiante*/

        /*crear Estudiante*/
        public bool GuardarEstudiante(EstudianteModel oEstudiante)
        {
            try
            {
                var cn = new Conexion();
                using var conexion = new SqlConnection(cn.GetCadenaSQL());

                SqlCommand cmd = new("sp_CrearEstudiante", conexion);
                cmd.Parameters.AddWithValue("@CodEstudiante", oEstudiante.CodEstudiante);
                cmd.Parameters.AddWithValue("@Nombre", oEstudiante.Nombre);
                cmd.Parameters.AddWithValue("@Edad", oEstudiante.Edad);
                cmd.Parameters.AddWithValue("@CodGrado", oEstudiante.CodGrado);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                return false;
            }
        }

        public bool EditarEstudiante(EstudianteModel oEstudiante)
        {
            try
            {
                var cn = new Conexion();

                using var conexion = new SqlConnection(cn.GetCadenaSQL());

                SqlCommand cmd = new("sp_CrearEstudiante", conexion);
                cmd.Parameters.AddWithValue("@CodEstudiante", oEstudiante.CodEstudiante);
                cmd.Parameters.AddWithValue("@Nombre", oEstudiante.Nombre);
                cmd.Parameters.AddWithValue("@Edad", oEstudiante.Edad);
                cmd.Parameters.AddWithValue("@CodGrado", oEstudiante.CodGrado);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                return false;
            }
        }

        public bool EliminarEstudiante(int codEstudiante)
        {
            try
            {
                var cn = new Conexion();
                using var conexion = new SqlConnection(cn.GetCadenaSQL());
                SqlCommand cmd = new("sp_CrearEstudiante", conexion);
                cmd.Parameters.AddWithValue("@CodEstudiante", codEstudiante);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                return false;
            }
        }
    }
}

