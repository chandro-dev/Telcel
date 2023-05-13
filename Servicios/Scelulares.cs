using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Scelulares:IServicios<celular>
    {
        private static List<celular> list;

        public Scelulares()
        {
            if (list == null)
            {
                list = new List<celular>();
            }

        }
        public bool add(celular celular)
        {
            try
            {
                list.Add(celular);
                return true;

            }
            catch
            {
                return false;
            }
        }
        public bool remove(celular celular)
        {

            try
            {
                list.Remove(celular);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool update(celular celular)
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
        public List<celular> GetCelulares()
        {
            return list;
        }
    }

}

