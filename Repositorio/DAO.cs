using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class DAO
    {

        ContextDb _dbContext;
        public DAO()
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
        public bool add_producto(asesorio p)
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
        public bool add_producto(producto p)
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
        public bool add_producto(computador p)
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
        public bool add_marca(marca p)
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
        public string add_producto(celular p)
        {
            try
            {
                return _dbContext.algo();
               
 
            }
            catch
            {
                return "";
            }
        }
        public  List<celular> GetProductos()
        {
            return null;
        }
        public string retorno()
        {

                return _dbContext.algo();
            
          

        }
        

    }
}
