using Entidades;
using System;
using System.Collections.Generic;
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
            using (SqlConnection connection = new SqlConnection("Server=RAPTOR-2;Database=TelCel;TrustServerCertificate=true;Trusted_Connection=true;MultipleActiveResultSets=true"))
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
                _asesorio.descuento = int.Parse(reader["descuento"].ToString());
            }
            catch
            {
            }
            return _asesorio;

        }
        public string add(asesorio item)
        {
            using (SqlConnection connection = new SqlConnection("Server=RAPTOR-2;Database=TelCel;TrustServerCertificate=true;Trusted_Connection=true;MultipleActiveResultSets=true"))
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
                    SqlParameter parameter = new SqlParameter("@imagen", SqlDbType.VarBinary, -1);
                    parameter.Value = item.imagen;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQuery();
                }
            }


            return "OK";
        }
            public string remove(asesorio item) 
        {
            using (SqlConnection connection = new SqlConnection("Server=RAPTOR-2;Database=TelCel;TrustServerCertificate=true;Trusted_Connection=true;MultipleActiveResultSets=true"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SPdelete_asesorio", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", item.id);
                    command.ExecuteNonQuery();
                }
            }


            return "ok";  
        }
        public string modify(asesorio item) 
        {
            return "ok";
        }
    }
}
