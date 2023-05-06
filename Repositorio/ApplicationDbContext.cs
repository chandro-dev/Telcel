using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class ApplicationDbContext: DbContext
    {

        
        public DbSet<cliente> clientes { get; set; }
        public DbSet<computador> computadores { get; set;}
        public DbSet<celular> celulars { get; set;}
        public DbSet<asesorio> asesorios { get; set;}
        public DbSet<factura> facturas { get; set;}


        protected override void OnConfiguring(DbContextOptionsBuilder options )
        {
            options.UseSqlServer("Server=RAPTOR-2;Database=TelCel;TrustServerCertificate=true;Trusted_Connection=true;MultipleActiveResultSets=true");
        }

    }
}
