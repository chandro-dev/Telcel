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
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        private static List<computador> computadors;
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.

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
