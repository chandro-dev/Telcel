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
    public class Sclientes
    {
            
        ContextDb _dbContext;
            public Sclientes()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContextDb>();
            optionsBuilder.UseSqlServer("Server=RAPTOR-2;Database=TelCel;TrustServerCertificate=true;Trusted_Connection=true;MultipleActiveResultSets=true");
            var options = optionsBuilder.Options;
            _dbContext = new ContextDb(options);
            _dbContext.Database.EnsureCreated();

        }

        public bool Add_Cliente(cliente cliente)
        {
            if (_dbContext != null) {
                try
                {
                    _dbContext.clientes.Add(cliente);
                    _dbContext.SaveChanges();
                    return true;
                }
                catch(Exception e)  {
                    Console.WriteLine(e.ToString());
                    return false;
                }
            }
            else { 
            return false;
            }
        
        
        }
    }
}
