using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventoAPI.Models.Seeds
{
    public class ParticipanteSeed : IEntityTypeConfiguration<Participante>
    {
        public void Configure(EntityTypeBuilder<Participante> builder)
        {
            builder.HasData(
                // Participantes para Conferencia de Tecnología 2025
                new Participante
                {
                    Id = 1,
                    Nombre = "Miguel Ángel Vásquez",
                    Email = "miguel.vasquez@email.com",
                    EventoId = 1
                },
                new Participante
                {
                    Id = 2,
                    Nombre = "Carmen Lucía Flores",
                    Email = "carmen.flores@email.com",
                    EventoId = 1
                },
                new Participante
                {
                    Id = 3,
                    Nombre = "Diego Alejandro Santos",
                    Email = "diego.santos@email.com",
                    EventoId = 1
                },
                new Participante
                {
                    Id = 4,
                    Nombre = "Andrea Valentina Cruz",
                    Email = "andrea.cruz@email.com",
                    EventoId = 1
                },
                new Participante
                {
                    Id = 5,
                    Nombre = "Sebastián Eduardo Rivas",
                    Email = "sebastian.rivas@email.com",
                    EventoId = 1
                },

                // Participantes para Seminario de Desarrollo Empresarial
                new Participante
                {
                    Id = 6,
                    Nombre = "Gabriela Monserrat Peña",
                    Email = "gabriela.pena@email.com",
                    EventoId = 2
                },
                new Participante
                {
                    Id = 7,
                    Nombre = "Alejandro Rafael Torres",
                    Email = "alejandro.torres@email.com",
                    EventoId = 2
                },
                new Participante
                {
                    Id = 8,
                    Nombre = "Isabella María Campos",
                    Email = "isabella.campos@email.com",
                    EventoId = 2
                },
                new Participante
                {
                    Id = 9,
                    Nombre = "Mauricio Ernesto Jiménez",
                    Email = "mauricio.jimenez@email.com",
                    EventoId = 2
                },
                new Participante
                {
                    Id = 10,
                    Nombre = "Valeria Stephania Aguilar",
                    Email = "valeria.aguilar@email.com",
                    EventoId = 2
                },

                // Participantes para Workshop de Innovación Digital
                new Participante
                {
                    Id = 11,
                    Nombre = "Daniel Francisco Ortega",
                    Email = "daniel.ortega@email.com",
                    EventoId = 3
                },
                new Participante
                {
                    Id = 12,
                    Nombre = "Natalia Esperanza Molina",
                    Email = "natalia.molina@email.com",
                    EventoId = 3
                },
                new Participante
                {
                    Id = 13,
                    Nombre = "Ricardo Mauricio Velasco",
                    Email = "ricardo.velasco@email.com",
                    EventoId = 3
                },
                new Participante
                {
                    Id = 14,
                    Nombre = "Paola Fernanda Guerrero",
                    Email = "paola.guerrero@email.com",
                    EventoId = 3
                },
                new Participante
                {
                    Id = 15,
                    Nombre = "Cristian Armando Salazar",
                    Email = "cristian.salazar@email.com",
                    EventoId = 3
                }
            );
        }
    }
}
