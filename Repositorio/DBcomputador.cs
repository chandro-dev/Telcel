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
    public class DBcomputador:Iproductos<computador>

    {
        public List<computador> getAll()
        {

            List<computador> computadors = new List<computador>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnection"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SPget_computadores", connection))
                {

                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            computadors.Add(mapper(reader));
                        }

                    }
                }
            }
            if (computadors.Count < 0)
            {
                return null;
            }
            return computadors;
        }
        private computador mapper(SqlDataReader reader)
        {

            var computador = new computador();

            computador.nombre = reader["nombre"].ToString();
            computador.imagen = (byte[])reader["imagen"];

            try
            {
                computador.id = int.Parse(reader["id"].ToString());
                computador.cantidad = int.Parse(reader["cantidad"].ToString());
                computador.almacenamiento = reader["almacenamiento"].ToString();
                computador.tarjeta_madre = reader["tarjeta_madre"].ToString();
                computador.tarjeta_video = reader["tarjeta_video"].ToString();
                computador.precio = double.Parse(reader["precio"].ToString());
                computador.marca = new marca
                {
                    id = int.Parse(reader["id_marca"].ToString()),

                    nombre_marca = reader["nombre_marca"].ToString()
                };
                computador.ram = reader["ram"].ToString();
                computador.procesador = reader["procesador"].ToString();
                computador.descuento = float.Parse(reader["descuento"].ToString());
                computador.envio = (bool)reader["envio"];
            }
            catch
            {

            }
            return computador;
        }
        public string add(computador item)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnection"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SPadd_computador", connection))
                {

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nombre", item.nombre);
                    command.Parameters.AddWithValue("@precio", item.precio);
                    command.Parameters.AddWithValue("@cantidad", item.cantidad);
                    command.Parameters.AddWithValue("@almacenamiento", item.almacenamiento);
                    command.Parameters.AddWithValue("@tarjeta_video", item.tarjeta_video);
                    command.Parameters.AddWithValue("@tarjeta_madre", item.tarjeta_madre);
                    command.Parameters.AddWithValue("@procesador", item.procesador);
                    command.Parameters.AddWithValue("@marca_nombre", item.marca.nombre_marca);
                    command.Parameters.AddWithValue("@descuento", item.descuento);
                    command.Parameters.AddWithValue("@envio", item.envio?1:0);
                    command.Parameters.AddWithValue("@ram", item.ram);
                    SqlParameter parameter = new SqlParameter("@imagen", SqlDbType.VarBinary, -1);
                    parameter.Value = item.imagen;

                    command.Parameters.Add(parameter);

                    command.ExecuteNonQuery();
                }
            }


            return "OK";
        }
        public string remove(computador item)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnection"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SPdelete_computador", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", item.id);
                    command.ExecuteNonQuery();
                }
            }


            return "OK";
        }
        public string modify(computador item)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnection"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SPupdate_computador", connection))
                {

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nombre", item.nombre);
                    command.Parameters.AddWithValue("@precio", item.precio);
                    command.Parameters.AddWithValue("@cantidad", item.cantidad);
                    command.Parameters.AddWithValue("@almacenamiento", item.almacenamiento);
                    command.Parameters.AddWithValue("@tarjeta_video", item.tarjeta_video);
                    command.Parameters.AddWithValue("@tarjeta_madre", item.tarjeta_madre);
                    command.Parameters.AddWithValue("@procesador", item.procesador);
                    command.Parameters.AddWithValue("@marca_nombre", item.marca.nombre_marca);
                    command.Parameters.AddWithValue("@descuento", item.descuento);
                    command.Parameters.AddWithValue("@envio", item.envio ? 1 : 0);
                    command.Parameters.AddWithValue("@ram", item.ram);
                    command.Parameters.AddWithValue("@id_producto", item.id);

                    SqlParameter parameter = new SqlParameter("@imagen", SqlDbType.VarBinary, -1);
                    parameter.Value = item.imagen;

                    command.Parameters.Add(parameter);

                    command.ExecuteNonQuery();
                }
            }


            return "Actualizado computador correctamente";
        }
    }
}
