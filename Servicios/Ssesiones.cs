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
        public persona validation(string password,string nombre )
        {
           return sesiones.GetPersonas().Find(x => x.contrasena == password && x.nombre == nombre);
        }

    }
}
