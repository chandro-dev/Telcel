using Entidades;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Sproducto:IServicios<producto>
    {

        private static List<producto> list;
        public Sproducto() {
            list = new List<producto>();
        }
        public bool add(producto p)
        {
            return true;
        }
        public bool remove(producto p) {
            return true;
        }
        public bool update(producto p)
        {
            return true;
        }
        public List<producto>GetProductos() {
            return list;
        }

    }
}
