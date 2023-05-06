using Entidades;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Sclientes
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public string addLCiente(cliente cliente)
        {

            db.clientes.Add(cliente);

            db.SaveChanges();
            return "ok";
        }
    }
}
