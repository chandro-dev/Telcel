using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Scomputadores:IServicios<computador>
    {
        private static List<computador> computadors;

        public Scomputadores()
        {
            if (computadors == null)
            {
                computadors = new List<computador>();
            }
        }
        public bool add(computador computador)
        {
            try
            {
                computadors.Add(computador);
                return true;

            }
            catch
            {
                return false;   
            }
        }
        public bool remove(computador computador)
        {

            try
            {
                computadors.Remove(computador);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool update(computador computador)
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
        public List<computador> GetComputadors()
        {
            return computadors;
        }
    }
}
