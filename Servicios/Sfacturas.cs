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
    public class Sfacturas 

    {
        private DBfactura _dao;
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        private static List<factura> facturas ;
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public Sfacturas()
        {
            _dao = new DBfactura();
            facturas = new List<factura>();
        }
        public string add(factura factura)
        {
            return _dao.add(factura);
        }
        public List<factura> GetHisto(persona p)
        {
            DBfactura _factura = new DBfactura();
            return _factura.getAll(p.cedula);
        }

        public factura GetProducts(factura f) {
            return _dao.GetDF(f);
        
        }

    }
}
