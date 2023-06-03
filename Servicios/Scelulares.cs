﻿using Entidades;
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
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
      private static List<celular> list;
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
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
#pragma warning disable CS8604 // Posible argumento de referencia nulo
            int index = list.IndexOf(list.Find(x => _celular.nombre == x.nombre));
#pragma warning restore CS8604 // Posible argumento de referencia nulo
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
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
                return null;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
            }
        }
    }

}

