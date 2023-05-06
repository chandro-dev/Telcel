using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Extensions.Options;

namespace Repositorio
{
    public class ContextDb:DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=RAPTOR-2;Database=TelCel;TrustServerCertificate=true;Trusted_Connection=true;MultipleActiveResultSets=true");
        }

        public ContextDb(): base()
        {

        }
        public DbSet<cliente>clientes { get; set; }

        public DbSet<computador>computadors { get; set; }   
        public DbSet<celular>celulars { get; set; }
        public DbSet<asesorio> asesorioes { get;}
        public DbSet<factura> facturas { get; set; }
       

    }
}