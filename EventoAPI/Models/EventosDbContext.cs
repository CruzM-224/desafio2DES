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
    }
}
