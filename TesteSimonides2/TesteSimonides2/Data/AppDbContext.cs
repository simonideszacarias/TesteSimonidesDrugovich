using Microsoft.EntityFrameworkCore;
using TesteSimonides2.Data.Map;
using TesteSimonides2.Models;

namespace TesteSimonides2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<GrupoCliente> GruposClientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new GerenteMap());
            modelBuilder.ApplyConfiguration(new GrupoMap());
            modelBuilder.ApplyConfiguration(new GrupoClienteMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
