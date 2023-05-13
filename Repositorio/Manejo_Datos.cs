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

        ContextDb _dbContext;
        public Manejo_Datos()
        {
            _dbContext = new ContextDb();
        }
        public bool add_cliente(persona p)
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
        public bool add_poducto(asesorio p)
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
        public bool add_poducto(computador p)
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
        public bool add_poducto(marca p)
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
        public bool add_poducto(celular p)
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
        

    }
}
