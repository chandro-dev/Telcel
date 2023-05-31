using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class DBpersonas
    {
        public string add(persona item)
        {
            using (SqlConnection connection = new SqlConnection("Server=RAPTOR-2;Database=TelCel;TrustServerCertificate=true;Trusted_Connection=true;MultipleActiveResultSets=true"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SPadd_persona", connection))
                {

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nombre", item.nombre);
                    command.Parameters.AddWithValue("@contrasena", item.contrasena);
                    command.Parameters.AddWithValue("@dirrecion", item.dirrecion);
                    command.Parameters.AddWithValue("@email", item.email);
                    command.Parameters.AddWithValue("@id_rol", item.rol.id);
                    command.Parameters.AddWithValue("@telefono", item.telefono);
                    command.Parameters.AddWithValue("@cedula", item.cedula);


                    command.ExecuteNonQuery();
                }
            }


            return "Guardado satisfacoriamente";
        }
        public List<persona> getAll()
        {
            List<persona> personas = new List<persona>();
            using (SqlConnection connection = new SqlConnection("Server=RAPTOR-2;Database=TelCel;TrustServerCertificate=true;Trusted_Connection=true;MultipleActiveResultSets=true"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SPselectallpersonas", connection))
                {

                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            personas.Add(mapper(reader));
                        }
                    }
                }
            }
            if (personas.Count < 0)
            {
                return null;
            }
            return personas;
        }
        public persona mapper(SqlDataReader reader)
        {

            var persona = new persona();

            persona.nombre = reader["nombre"].ToString();
            persona.cedula= int.Parse(reader["cedula"].ToString());

            try
            {
                persona.telefono = reader["telefono"].ToString();
                persona.dirrecion = reader["dirrecion"].ToString();
                persona.email = reader["email"].ToString();
                persona.contrasena = reader["contrasena"].ToString();
                persona.rol = new rol() { id = int.Parse(reader["id_rol"].ToString()) };


            }
            catch
            {
            }
            return persona;

        }
    }
}
