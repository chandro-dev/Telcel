using Entidades;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Sesiones
    {


        ContextDb _dbContext= new ContextDb();
        public bool InitSesion(cliente c)
        {

            if (_dbContext.clientes.Where(x => x.id == c.id && x.contrasena == c.contrasena) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
