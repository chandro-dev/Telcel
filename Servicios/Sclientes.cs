using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{

    /*
     * Se relizan todas las validaciones correspondientes al manejo de los clientes
     * 
     * Se cumplen con los requerimientos dados por la vista correspondiente a la entrega de datos y su respectivo manejo.
     */
    public class Sclientes
    {

        Manejo_Datos M_datos;
     
        public Sclientes()
        {
            M_datos= new Manejo_Datos(); 
        }

        public bool Add_Cliente(persona cliente)
        {
            if (M_datos.add_cliente(cliente))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool sesion(persona cliente)
        {
            if (true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<persona> GetClientes()
        {
            return Manejo_Datos.get_personas();
        }
      
        public List<persona> getAdmin()
        {
            return null;
        }
        
    }
}
