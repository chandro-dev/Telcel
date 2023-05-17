using Entidades;
using Repositorio;
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
        DAO dao;
        Sproducto sproducto;

        public Scelulares()
        {
            if (list == null)
            {
                list = new List<celular>();
            }
            sproducto= new Sproducto();
            dao = new DAO();
        }
        public string add(celular celular)
        {
            try
            {
                list.Add(celular);
                return dao.retorno().ToString();
              
   
            }
            catch
            {
                return "";
            }
        }
        public bool remove(celular celular)
        {

            try
            {
                list.Remove(celular);
                sproducto.remove((producto)celular);
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

