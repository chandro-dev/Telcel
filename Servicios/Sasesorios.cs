﻿using Entidades;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Sasesorios
    {
        List<asesorio> list;
        Iproductos<asesorio> dao;
        public Sasesorios()
        {
            if (list == null)list = new List<asesorio>();
            
            dao= new DBasesorios();
        }
        public string add(asesorio asesorio)
        {
            list.Add(asesorio);
            return dao.add(asesorio);
        }
        public string remove(asesorio asesorio)
        {
            int index = list.IndexOf(list.Find(x => asesorio.id == x.id));
            string result = dao.remove(list[index]);
            list.Remove(asesorio);
            return result;
        }

        public string update(asesorio asesorio)
        {

            return dao.modify(asesorio);
        }
        public List<asesorio> GetAsesorios()
        {
            list = dao.getAll();
            return list;
        }
    }
}

