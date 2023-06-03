using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Ssesiones
    {
        Sclientes sesiones;
        public Ssesiones() {
        
            sesiones = new Sclientes();
        }
        public persona validation(string password,string email )
        {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
           return sesiones.GetPersonas().Find(x => x.contrasena.Equals(password) && x.email.Equals(email));
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
        }


    }
}
