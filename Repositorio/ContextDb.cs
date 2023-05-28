using Entidades;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Permissions;

namespace Repositorio
{
    public class ContextDb
    {
        public static string retorno = "algo";
        public ContextDb()
        {

        }

        public string algo()
        {
            return retorno;
        }
        public bool add_producto(producto p)
        { 
            
            return true;
        }
        public bool add_persona(persona p)
        {
            using (SqlConnection connection = new SqlConnection("Server=RAPTOR-2;Database=TelCel;TrustServerCertificate=true;Trusted_Connection=true;MultipleActiveResultSets=true"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("insertar_clientes", connection))
                {

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@cedula", p.cedula);
                    command.Parameters.AddWithValue("@dirrecion", p.dirrecion);
                    command.Parameters.AddWithValue("@contrasena", p.contrasena);
                    command.Parameters.AddWithValue("@telefono", p.telefono);
                    command.Parameters.AddWithValue("@nombre", p.nombre);
                    command.Parameters.AddWithValue("@id_rol", p.rol.id);
                    command.Parameters.AddWithValue("@email", p.email);
                    command.ExecuteNonQuery();
                    Console.WriteLine("**EJECUTANDO PROCEDIMIENTO ALMACENADO*********************");
                }
            }
            return true;
        }
      
    }
}

    
