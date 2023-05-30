using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using System.Data.SqlClient;

namespace Repositorio.Oracle
{
    public class DBOpersona:Iproductos<persona>
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;

        public List<persona> getAll() {
            var list = new List<persona>();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                // Abrir la conexión
                connection.Open();
                using (OracleCommand command = new OracleCommand("ppersonas.fget_personas", connection))
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
    public persona mapper(OracleDataReader reader)
    {

        var persona = new persona();

                persona.email = reader.GetString("email");
                persona.contrasena = reader.GetString("contrasena");

                try
        {
                    persona.nombre = reader.GetString("nombre");
                    persona.cedula = reader.GetInt32("cedula");
                    persona.telefono = reader.GetString("telefono");
            persona.dirrecion = reader.GetString("dirrecion");

            persona.rol = new rol() { id = reader.GetInt32("id_rol") };


        }
        catch
        {
        }
        return persona;

    }
    public string add(persona item)
        {
            return null;
        }
        public string remove(persona item) { return null; 
        }
        public string modify(persona item) { return null; }
    }

}
