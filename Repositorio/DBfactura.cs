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
    public class DBfactura
    {
        public string add(factura factura)
        {
            using (SqlConnection connection = new SqlConnection("Server=RAPTOR-2;Database=TelCel;TrustServerCertificate=true;Trusted_Connection=true;MultipleActiveResultSets=true"))
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
    }
}
