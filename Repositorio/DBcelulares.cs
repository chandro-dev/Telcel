using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class DBcelulares:Iproductos<celular>
    {
        public List<celular> getAll() {

            List<celular> celulars = new List<celular>();
            using (SqlConnection connection = new SqlConnection("Server=RAPTOR-2;Database=TelCel;TrustServerCertificate=true;Trusted_Connection=true;MultipleActiveResultSets=true"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SPGetcelulares", connection))
                {

                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            celulars.Add(mapper(reader));
                        }
                       
                    }
                }
            }
            if (celulars.Count < 0)
            {
                return null;
            }
            return celulars;
        }
        public string add(celular item) {
            using (SqlConnection connection = new SqlConnection("Server=RAPTOR-2;Database=TelCel;TrustServerCertificate=true;Trusted_Connection=true;MultipleActiveResultSets=true"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SPadd_celular", connection))
                {

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nombre",item.nombre );
                    command.Parameters.AddWithValue("@precio", item.precio);
                    command.Parameters.AddWithValue("@cantidad", item.cantidad);
                    command.Parameters.AddWithValue("@descripcion", item.descripcion);
                    command.Parameters.AddWithValue("@almacenamiento", item.almacenamiento);
                    command.Parameters.AddWithValue("@marca_nombre", item.marca.nombre_marca);
                    command.Parameters.AddWithValue("@envio", item.envio ? 1:0) ;
                    command.Parameters.AddWithValue("@descuento", item.descuento);

                    command.Parameters.AddWithValue("@camara", item.camara);
                    command.Parameters.AddWithValue("@ram", item.ram);
                    SqlParameter parameter = new SqlParameter("@imagen", SqlDbType.VarBinary, -1);
                    parameter.Value = item.imagen;
                    command.Parameters.Add(parameter);

                    command.ExecuteNonQuery();
         
                }
            } 
            

            return "OK";
        }
       private celular mapper(SqlDataReader reader)
        {

            var celular =new celular();

            celular.nombre = reader["nombre"].ToString();
            celular.imagen = (byte[])reader["imagen"];

            try
            {
                celular.id = int.Parse(reader["id"].ToString());
                celular.cantidad = int.Parse(reader["cantidad"].ToString());
                celular.almacenamiento = reader["almacenamiento"].ToString();
                celular.camara = reader["camara"].ToString();
                celular.descripcion = reader["descripcion"].ToString();
                celular.precio = double.Parse(reader["precio"].ToString());
                celular.marca = new marca
                {
                    id = int.Parse(reader["id_marca"].ToString()),

                    nombre_marca = reader["nombre_marca"].ToString()
                };
                celular.ram = reader["ram"].ToString();
                celular.descuento = float.Parse(reader["descuento"].ToString());
                celular.envio = (bool)reader["envio"];
            }
            catch
            {

            }
            return celular;
        }
        public string remove(celular item) {
            using(SqlConnection connection = new SqlConnection("Server=RAPTOR-2;Database=TelCel;TrustServerCertificate=true;Trusted_Connection=true;MultipleActiveResultSets=true"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SPdelete_celular", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", item.id);
                    command.ExecuteNonQuery();
                }
            }


            return "OK";
        }
        public string modify(celular item) {
            using (SqlConnection connection = new SqlConnection("Server=RAPTOR-2;Database=TelCel;TrustServerCertificate=true;Trusted_Connection=true;MultipleActiveResultSets=true"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SPupdate_celular", connection))
                {

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nombre", item.nombre);
                    command.Parameters.AddWithValue("@precio", item.precio);
                    command.Parameters.AddWithValue("@cantidad", item.cantidad);
                    command.Parameters.AddWithValue("@descripcion", item.descripcion);
                    command.Parameters.AddWithValue("@almacenamiento", item.almacenamiento);
                    command.Parameters.AddWithValue("@marca_nombre", item.marca.nombre_marca);
                    command.Parameters.AddWithValue("@envio", item.envio ? 1 : 0);
                    command.Parameters.AddWithValue("@descuento", item.descuento);
                    command.Parameters.AddWithValue("@id_producto", item.id);
                    command.Parameters.AddWithValue("@camara", item.camara);
                    command.Parameters.AddWithValue("@ram", item.ram);
                    SqlParameter parameter = new SqlParameter("@imagen", SqlDbType.VarBinary, -1);
                    parameter.Value = item.imagen;
                    command.Parameters.Add(parameter);

                    command.ExecuteNonQuery();

                }
            }


            return "Actualizado Correctamente";
        }
    }
}
