using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;

namespace Repositorio
{
    public class DBfactura
    {
        public string add(factura factura)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnection"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SPadd_factura", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@fecha", SqlDbType.Date).Value = factura.fecha;
                    command.Parameters.Add("@fecha_entrega", SqlDbType.Date).Value = factura.fecha_entrega;
                    command.Parameters.AddWithValue("@tipo_pago", factura.tipo_pago);
                    command.Parameters.AddWithValue("@cedula",factura.cliente.cedula);

                    command.Parameters.Add("@id_factura", SqlDbType.Int).Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();

                    factura.id = Convert.ToInt32(command.Parameters["@id_factura"].Value);

                }
                foreach( producto p in factura.productos)
                using (SqlCommand command = new SqlCommand("SPadd_detalle_factura", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_producto", p.id);
                    command.Parameters.AddWithValue("@id_factura", factura.id);
                    command.Parameters.AddWithValue("@cantidad", 1);


                    command.ExecuteNonQuery();


                }
            }


            return "OK";
        }
        public List<factura> getAll(int cedula)
        {

            List<factura> facturas = new List<factura>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnection"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SPget_factuas", connection))
                {

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@cedula", SqlDbType.VarChar).Value = cedula;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            facturas.Add(mapper(reader));
                        }
                    }
                }
                       
                
            }
            if (facturas.Count < 0)
            {
                return null;
            }
            return facturas;
        }
        public factura GetDF(factura f)
        {
            List<producto> detail_F = new List<producto>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnection"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SPget_df", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@id_factura", SqlDbType.Int).Value = f.id;
                    command.ExecuteNonQuery();
                    using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        detail_F.Add(new producto()
                        {
                            nombre = reader["nombre"].ToString(),
                            cantidad = int.Parse(reader["cantidad"].ToString()),
                            precio = double.Parse(reader["precio"].ToString()),
                            id = int.Parse(reader["id"].ToString()),
                            descuento = float.Parse(reader["descuento"].ToString()),
                            envio = (bool)reader["envio"]
                        });
                    }
                }
            
                
                }
            }
            f.productos=detail_F;
            return f;
        }
        private factura  mapper(SqlDataReader reader)
        {

            var _factutra= new factura();

            _factutra.fecha= DateTime.Parse(reader["fecha"].ToString());
            _factutra.fecha_entrega = DateTime.Parse(reader["fecha_entrega"].ToString());
            _factutra.total = double.Parse(reader["total"].ToString());
            _factutra.id = int.Parse(reader["id_factura"].ToString());
            _factutra.tipo_pago = reader["tipo_pago"].ToString();
        return _factutra;
        }
    }


}
