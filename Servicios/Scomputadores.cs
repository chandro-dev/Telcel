using Entidades;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Scomputadores
    {
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        private static List<computador> computadors;
        Sproducto sproducto;
        Iproductos<computador> dao;


        public Scomputadores()
        {
            if (computadors == null)
            {
                computadors = new List<computador>();
            }
            sproducto = new Sproducto();
            dao = new DBcomputador();
          
        }
        public string add(computador computador)
        {

                computadors.Add(computador);
                return dao.add(computador) ;

        }
        public bool remove(computador computador)
        {

            try
            {
                computadors.Remove(computador);
                sproducto.remove(computador);
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
            return dao.getAll();
        }
    }
}
