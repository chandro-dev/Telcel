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
        DAO dao;
        private static List<producto> list;
        public Sproducto() {
            if (list == null)
            {
                list = new List<producto>();
            }
            dao= new DAO();
        }
        public bool add(producto p)
        {
          
            try
            {
                
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool remove(producto p) {

            try
            {
                list.Remove(p);
                return true;
            }
            catch
            {
                return false;
            }
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
