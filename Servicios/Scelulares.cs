using Entidades;
using Repositorio;
using Repositorio.Oracle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Scelulares//:IServicios<celular>
    {
      private static List<celular> list;
       Iproductos<celular> dao;
        Sproducto sproducto;

        public Scelulares()
        {
            if (list == null)
            {
                list = new List<celular>();
            }

            sproducto= new Sproducto();
            dao = new DBcelulares();
            list=dao.getAll();
        }
        public string add(celular celular)
        {
       
                list.Add(celular);
                return dao.add(celular);


        }
        public string remove(celular _celular)
        {
            int index = list.IndexOf(list.Find(x => _celular.nombre == x.nombre));
                string result = dao.remove(list[index]);
                list.Remove(_celular);
                return result;
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
            try
            {
                return list;

            }
            catch
            {
                return null;
            }
        }
    }

}

