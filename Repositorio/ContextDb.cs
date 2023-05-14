using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Extensions.Options;

namespace Repositorio
{
    internal class ContextDb:DbContext
    {
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public ContextDb()
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=RAPTOR-2;Database=TelCel;TrustServerCertificate=true;Trusted_Connection=true;MultipleActiveResultSets=true");
        }

        public DbSet<marca> marcas { get; set; }
        public DbSet<rol> roles { get; set; }
        public DbSet<persona>clientes { get; set; }
        public DbSet<computador>computadors { get; set; }   
        public DbSet<celular>celulars { get; set; }
        public DbSet<asesorio> asesorioes { get;}
        public DbSet<factura> facturas { get; set; }
        public DbSet<producto> productos { get; set; }

    }
}