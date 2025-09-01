using EventoAPI.Models.Seeds;
using Microsoft.EntityFrameworkCore;

namespace EventoAPI.Models
{
    public class EventosDbContext: DbContext
    {
        public EventosDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Organizador> Organizadores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventoSeed());
            modelBuilder.ApplyConfiguration(new OrganizadorSeed());
            modelBuilder.ApplyConfiguration(new ParticipanteSeed());
        }
    }
}
