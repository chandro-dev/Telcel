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
    public class DBmarca
    {
        public List<marca> getAll()
        {

            List<marca> marcas= new List<marca>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnection"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SPget_marcas", connection))
                {

                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            marcas.Add(mapper(reader));
                        }

                    }
                }
            }
            if (marcas.Count < 0)
            {
                return null;
            }
            return marcas;
        }
        private marca mapper(SqlDataReader reader)
        {

            var _marca = new marca();

        _marca.nombre_marca = reader["nombre"].ToString();
            _marca.id= int.Parse(reader["id_marca"].ToString());
            
            return _marca;
        }
    }
}

