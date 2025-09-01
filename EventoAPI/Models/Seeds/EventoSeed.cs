using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EventoAPI.Models.Seeds
{
    public class EventoSeed : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.HasData(
                new Evento
                {
                    Id = 1,
                    Nombre = "Conferencia de Tecnología 2025",
                    Fecha = new DateTime(2025, 10, 15),
                    Lugar = "Centro de Convenciones San Salvador"
                },
                new Evento
                {
                    Id = 2,
                    Nombre = "Seminario de Desarrollo Empresarial",
                    Fecha = new DateTime(2025, 11, 20),
                    Lugar = "Hotel Real InterContinental"
                },
                new Evento
                {
                    Id = 3,
                    Nombre = "Workshop de Innovación Digital",
                    Fecha = new DateTime(2025, 12, 5),
                    Lugar = "Universidad Don Bosco"
                }
            );
        }
    }
}
