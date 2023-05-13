using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Sfacturas :IServicios<factura>


    {
        private static List<factura> facturas = new List<factura>();

        public bool add(factura factura)
        {
            throw new NotImplementedException();
        }

        public bool remove(factura factura)
        {
            throw new NotImplementedException();
        }

        public bool update(factura factura)
        {
            throw new NotImplementedException();
        }
    }
}
