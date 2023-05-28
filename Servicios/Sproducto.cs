using Entidades;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Sproducto
    {

        private static List<producto> list;
        Iproductos<producto> dao;
        public Sproducto() {
            if (list == null)
            {
                list = new List<producto>();
            }
            dao = new DBproductos();

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
            return dao.getAll();
        }
        public List<producto>GetProductos(string type)
        {
            switch (type)
            {
                case "Computadores":
                    var scomputadores = new Scomputadores();
                    return scomputadores.GetComputadors().ToList<producto>();
                case "Celulares":
                    var scelulares = new Scelulares();
                    return scelulares.GetCelulares().ToList<producto>();
                case "Asesorios":
                    var sasesorios = new Sasesorios();
                    return sasesorios.GetAsesorios().ToList<producto>();
                default:
                    return dao.getAll();    

            }
        }
        public List<marca> GetMarcas()
        {
            var _dao = new DBmarca();
            return _dao.getAll();
        }
    }
}
