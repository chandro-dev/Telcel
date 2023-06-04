using Entidades;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Oracle.ManagedDataAccess;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Repositorio.Oracle
{
    public class DBOcelulares:Iproductos<celular>
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
        public List<celular> getAll()
        {
            var list = new List<celular>();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                // Abrir la conexión
                connection.Open();
                using (OracleCommand command = new OracleCommand("pcelulares.Fget_Celulares", connection))
                {
                    // Especificar el tipo de comando como función
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("resultado", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.ReturnValue;

                    // Ejecutar el comando
                    command.ExecuteNonQuery();

                    // Obtener el cursor de salida
                    OracleDataReader reader = ((OracleRefCursor)command.Parameters["resultado"].Value).GetDataReader();

                    // Verificar si hay filas devueltas
                    if (reader.HasRows)
                    {
                        // Recorrer las filas
                        while (reader.Read())
                        {
                            list.Add(mapper(reader));

                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontraron filas.");
                    }
                }
            }

            return list;

        }
        public celular mapper(OracleDataReader reader)
        {

            var celular = new celular();

            celular.nombre = reader.GetString("nombre");
            celular.descripcion = reader.GetString("descripcion");

            try
            {
                 celular.id = reader.GetInt32("id_producto");
                OracleBlob blob = reader.GetOracleBlob(8);
                byte[] array = new byte[blob.Length];
                blob.Read(array, 0,array.Length);
                celular.imagen = array;
                celular.marca=  new marca { id = reader.GetInt32("id_marca") };
                celular.cantidad= reader.GetInt32("cantidad");
                celular.camara = reader.GetString("camara");
                celular.ram = reader.GetString("ram") ;
            }
            catch
            {
            }
            return celular;

        }
        public string add(celular item){

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                // Abrir la conexión
                connection.Open();
                using (OracleCommand command = new OracleCommand("pcelulares.SPadd_celular", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("vcamara", OracleDbType.Varchar2).Value = item.camara;
                    command.Parameters.Add("vram", OracleDbType.Varchar2).Value = item.ram;
                    command.Parameters.Add("vmarca_nombre", OracleDbType.Varchar2).Value = item.marca.nombre_marca;
                    command.Parameters.Add("valmacenamiento", OracleDbType.Varchar2).Value = item.almacenamiento;
                    command.Parameters.Add("vnombre", OracleDbType.Varchar2).Value = item.nombre;
                    command.Parameters.Add("vdescripcion", OracleDbType.Varchar2).Value = item.descripcion;
                    command.Parameters.Add("vprecio", OracleDbType.Int64).Value = item.precio;
                    command.Parameters.Add("vcantidad", OracleDbType.Int32).Value = item.cantidad;



                    command.ExecuteNonQuery();

                }
            }
            return "ok";
        }
       

        public string remove(celular item)
        {
            return null;
        }
        public string modify(celular item)
        {
            return null;
        }
    }
}
