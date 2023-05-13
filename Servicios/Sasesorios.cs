using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Sasesorios
    {
        private static List<asesorio> list;

        public Sasesorios()
        {
            if (list == null)
            {
                list = new List<asesorio>();
            }
        }
        public bool add(asesorio asesorio)
        {
            try
            {
                    list.Add(asesorio);
                return true;

            }
            catch
            {
                return false;
            }
        }
        public bool remove(asesorio asesorio)
        {

            try
            {
                list.Remove(asesorio);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool update(asesorio asesorio)
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
        public List<asesorio> GetAsesorios()
        {
            return list;
        }
    }
}

