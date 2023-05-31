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
        List<computador> list;
        Iproductos<computador> dao;
        public Scomputadores()
        {
            if (list == null) list = new List<computador>();
            dao = new DBcomputador();
            list = dao.getAll();
        }
        public string add(computador computador)
        {

                list.Add(computador);
                return dao.add(computador) ;

        }
        public string remove(computador computador)
        { 
             int index = list.IndexOf(list.Find(x => computador.id == x.id));
            string result = dao.remove(list[index]);
            list.Remove(computador);
            return result;
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
            list = dao.getAll();
            return list;
        }
    }
}
