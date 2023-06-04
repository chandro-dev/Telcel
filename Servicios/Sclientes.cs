using Entidades;

using Repositorio;
using Repositorio.Oracle;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.OracleClient;
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
        private  List<persona> personas;
        DBpersonas _dao = new DBpersonas ();
        public Sclientes()
        {

            if(personas == null)
            {
                personas=new List<persona>();
            }
        }

        public string add(persona cliente)
        {
            if (cliente == null)
                return "No se guardo Satisfactoriamente al cliente";
            personas.Add(cliente);
                return _dao.add(cliente);
  
        }
        public string remove(persona cliente)
        {
            return _dao.remove(cliente);
        }
        public string update(persona cliente) {
            return _dao.modify(cliente);
        }
      
        public List<persona> GetPersonas()
        {
            personas = _dao.getAll();
            return personas;
        }
        public List<persona> GetClientes()
        {
            personas = _dao.getAll();
            return personas;

        }
       
        
    }
}
