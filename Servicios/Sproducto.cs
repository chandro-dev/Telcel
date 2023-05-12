using Entidades;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Sproducto
    {
        Manejo_Datos M_datos;
        public Sproducto() {
            M_datos = new Manejo_Datos();
        }
        public void add(asesorio p)
        {
            M_datos.add_poducto(p);
        }
        public List<asesorio> list() {
            return Manejo_Datos.get_asesorios();
        }

    }
}
