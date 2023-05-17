using Entidades;
using System.Configuration;
using System.Data.SqlClient;

namespace Repositorio
{
    internal class ContextDb
    {
       public static string retorno="algo";
        public ContextDb()
        {
            using(SqlConnection connection = new SqlConnection("Server=RAPTOR-2;Database=TelCel;TrustServerCertificate=true;Trusted_Connection=true;MultipleActiveResultSets=true"))
        {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SPHW", connection))
                {
                   
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    retorno = "ejecutando procedimiento almacenado";
                    // Agrega parámetros si el procedimiento almacenado los requiere
                    // command.Parameters.AddWithValue("@Parametro", valor);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Accede a los datos del resultado
                            var columna1 = reader;

                            // Realiza las operaciones necesarias con los datos
                            retorno=$"Columna1: {columna1}";
                         
                        }
                    }
                }
            }
        }
       
        public string algo()
        {
            return retorno;
        }
    }
}