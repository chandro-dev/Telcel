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
    public class DBproductos:Iproductos<producto>
    {
        public List<producto> getAll()
        {

            List<producto> productos = new List<producto>();
            using (SqlConnection connection = new SqlConnection("Server=RAPTOR-2;Database=TelCel;TrustServerCertificate=true;Trusted_Connection=true;MultipleActiveResultSets=true"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SPget_productos", connection))
                {

                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productos.Add(mapper(reader));
                        }

                    }
                }
            }
            if (productos.Count < 0)
            {
                return null;
            }
            return productos;
        }
        private producto mapper(SqlDataReader reader)
        {

            var producto = new producto();

            producto.nombre = reader["nombre"].ToString();
            producto.imagen = (byte[])reader["imagen"];

            try
            {

                producto.cantidad = int.Parse(reader["cantidad"].ToString());
  
                producto.precio = double.Parse(reader["precio"].ToString());
                producto.id = int.Parse(reader["id"].ToString());
                producto.marca = new marca
                {
                    id = int.Parse(reader["id_marca"].ToString()),

                    nombre_marca = reader["nombre_marca"].ToString()
                };
                producto.descuento = int.Parse(reader["descuento"].ToString());

            }
            catch
            {

            }
            return producto;
        }
        public string add(producto item)
        {
            using (SqlConnection connection = new SqlConnection("Server=RAPTOR-2;Database=TelCel;TrustServerCertificate=true;Trusted_Connection=true;MultipleActiveResultSets=true"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SPadd_computador", connection))
                {

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nombre", item.nombre);
                    command.Parameters.AddWithValue("@precio", item.precio);
                    command.Parameters.AddWithValue("@cantidad", item.cantidad);
                    SqlParameter parameter = new SqlParameter("@imagen", SqlDbType.VarBinary, -1);
                    parameter.Value = item.imagen;

                    command.Parameters.Add(parameter);

                    command.ExecuteNonQuery();
                }
            }


            return "OK";
        }
        public string remove(producto item)
        {
            return "OK";
        }
        public string modify(producto item)
        {
            return "OK";
        }
    }
}
