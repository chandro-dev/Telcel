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
using System.Runtime.CompilerServices;

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
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                // Abrir la conexión
                connection.Open();
                using (OracleCommand command = new OracleCommand("ppersonas.SPADD_persona", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("vnombre", OracleDbType.Varchar2).Value =item.nombre;
                    command.Parameters.Add("vcedula", OracleDbType.Int32).Value = item.cedula;
                    command.Parameters.Add("vdirrecion", OracleDbType.Varchar2).Value = item.dirrecion;
                    command.Parameters.Add("veamil", OracleDbType.Varchar2).Value = item.email;
                    command.Parameters.Add("vtelefono", OracleDbType.Varchar2).Value = item.telefono;
                    command.Parameters.Add("vcontrasena", OracleDbType.Varchar2).Value = item.contrasena;
                    command.Parameters.Add("vid_rol", OracleDbType.Int32).Value = item.rol.id;

                    command.ExecuteNonQuery();

                }
            }
                    return "ok";
        }
        public string remove(persona item) { return null; 
        }
        public string modify(persona item) { return null; }
    }

}
