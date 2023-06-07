using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class DBasesorios:Iproductos<asesorio>
    {
        public List<asesorio> getAll() {
            List<asesorio> asesorios = new List<asesorio>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnection"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SPGet_asesorios", connection))
                {

                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            asesorios.Add(mapper(reader));
                        }
                    }
                }
            }
            if (asesorios.Count < 0)
            {
                return null;
            }
            return asesorios;
        }
        public asesorio mapper(SqlDataReader reader)
        {

            var _asesorio = new asesorio();

            _asesorio.nombre = reader["nombre"].ToString();
            _asesorio.imagen = (byte[])reader["imagen"];

            try
            {
                _asesorio.id = int.Parse(reader["id"].ToString());

                _asesorio.cantidad= int.Parse(reader["cantidad"].ToString());
                _asesorio.precio = double.Parse(reader["precio"].ToString());
                _asesorio.marca = new marca
                {
                    id = int.Parse(reader["id_marca"].ToString()),
                    nombre_marca = reader["nombre_marca"].ToString()
                };
                _asesorio.referencia= reader["referencia"].ToString();
                _asesorio.descuento = float.Parse(reader["descuento"].ToString());
                _asesorio.envio = (bool)reader["envio"];
          
            }
            catch
            {
            }
            return _asesorio;

        }
        public string add(asesorio item)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnection"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SPadd_asesorio", connection))
                {

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nombre", item.nombre);
                    command.Parameters.AddWithValue("@precio", item.precio);
                    command.Parameters.AddWithValue("@cantidad", item.cantidad);
                    command.Parameters.AddWithValue("@referencia", item.referencia);
                    command.Parameters.AddWithValue("@marca_nombre", item.marca.nombre_marca);
                    command.Parameters.AddWithValue("@descuento", item.descuento);
                    command.Parameters.AddWithValue("@envio",item.envio? 1: 0);
                    SqlParameter parameter = new SqlParameter("@imagen", SqlDbType.VarBinary, -1);
                    parameter.Value = item.imagen;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQuery();
                }
            }


            return "Asesorio añadido corectamente";
        }
            public string remove(asesorio item) 
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnection"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SPdelete_asesorio", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", item.id);
                    command.ExecuteNonQuery();
                }
            }


            return "Eliminado corectamente";  
        }
        public string modify(asesorio item) 
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnection"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SPupdate_asesorio", connection))
                { 
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nombre", item.nombre);
                    command.Parameters.AddWithValue("@precio", item.precio);
                    command.Parameters.AddWithValue("@cantidad", item.cantidad);
                    command.Parameters.AddWithValue("@referencia", item.referencia);
                    command.Parameters.AddWithValue("@marca_nombre", item.marca.nombre_marca);
                    command.Parameters.AddWithValue("@descuento", item.descuento);
                    command.Parameters.AddWithValue("@envio", item.envio ? 1 : 0);
                    command.Parameters.AddWithValue("@id_producto", item.id);
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
