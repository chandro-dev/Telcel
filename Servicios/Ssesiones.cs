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
           return sesiones.GetPersonas().Find(x => x.contrasena.Equals(password) && x.email.Equals(email));
        }


    }
}
