using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class Manejo_Datos
    {
        private static List<marca> marcas = new List<marca>();
        private static List<rol> roles = new List<rol>();
        private static List<persona> personas = new List<persona>();
        private static List<computador> computadors = new List<computador>();
        private static List<celular> celulars = new List<celular>();
        private static List<asesorio> asesorioes = new List<asesorio>();
        private static List<factura> facturas = new List<factura>();
        ContextDb _dbContext;
        public Manejo_Datos()
        {
            _dbContext = new ContextDb();
        }
        public bool add_cliente(persona p)
        {
            try
            {
                personas.Add(p);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool add_poducto(producto p)
        {
            try
            {
                asesorioes.Add((asesorio)p);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Retorno de listas;
        public static List<persona> get_personas() {
            if (personas != null)
            {
                return personas.ToList();
            }
            else
            {
                return null;
            }
        }
        public static List<asesorio> get_asesorios()
        {
            return asesorioes;
        }

    }
}
