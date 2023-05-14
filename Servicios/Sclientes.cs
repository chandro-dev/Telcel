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
    public class Sclientes:IServicios<persona>
    {
        private static List<rol> roles = new List<rol>();
        private static List<persona> personas;
     
        public Sclientes()
        {
            if(personas == null)
            {
                personas=new List<persona>(){new persona()
                {
                    nombre="admin",
                    cedula=666,
                    contrasena="admin",
                    rol= new rol
                    {
                        id=0,
                        Rol="admin"
                    },
                    telefono="2222",
                    email="admin.com",
                    dirrecion="admin",
                    id=0
                } };
            }
        }

        public bool add(persona cliente)
        {
            try
            {
                personas.Add(cliente);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool remove(persona cliente)
        {
            return true;
        }
        public bool update(persona cliente) {
            return true;
        }
      
        public List<persona> GetPersonas()
        {
            return personas;
        }
        public List<persona> GetClientes()
        {
            return personas.FindAll(x=>x.rol.Rol =="cliente");
        }
      

        
    }
}
