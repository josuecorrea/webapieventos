using ApiEventosCore.Data.EntitieTypeConfiguration;
using ApiEventosCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEventosCore.Data
{
    public class EventosDataContext : DbContext
    {
        public EventosDataContext()
        {
            
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Evento> Evento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new EventoMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
