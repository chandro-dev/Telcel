﻿using Entidades;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Sfacturas 

    {
        private DBfactura _dao;
        private static List<factura> facturas ;
        public Sfacturas()
        {
            _dao = new DBfactura();
            facturas = new List<factura>();
        }
        public string add(factura factura)
        {
            return _dao.add(factura);
        }

        
    }
}
