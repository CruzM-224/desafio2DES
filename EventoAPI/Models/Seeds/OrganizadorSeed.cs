using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventoAPI.Models.Seeds
{
    public class OrganizadorSeed : IEntityTypeConfiguration<Organizador>
    {
        public void Configure(EntityTypeBuilder<Organizador> builder)
        {
            builder.HasData(
                // Organizadores para Conferencia de Tecnología 2025
                new Organizador
                {
                    Id = 1,
                    Nombre = "Ana María García",
                    Cargo = "Coordinadora General",
                    EventoId = 1
                },
                new Organizador
                {
                    Id = 2,
                    Nombre = "Carlos Roberto Méndez",
                    Cargo = "Director Técnico",
                    EventoId = 1
                },
                new Organizador
                {
                    Id = 3,
                    Nombre = "María Elena Rodríguez",
                    Cargo = "Coordinadora de Logística",
                    EventoId = 1
                },

                // Organizadores para Seminario de Desarrollo Empresarial
                new Organizador
                {
                    Id = 4,
                    Nombre = "José Antonio López",
                    Cargo = "Director Ejecutivo",
                    EventoId = 2
                },
                new Organizador
                {
                    Id = 5,
                    Nombre = "Patricia Isabel Martínez",
                    Cargo = "Gerente de Eventos",
                    EventoId = 2
                },
                new Organizador
                {
                    Id = 6,
                    Nombre = "Roberto Carlos Hernández",
                    Cargo = "Coordinador Académico",
                    EventoId = 2
                },

                // Organizadores para Workshop de Innovación Digital
                new Organizador
                {
                    Id = 7,
                    Nombre = "Laura Beatriz Castillo",
                    Cargo = "Directora de Innovación",
                    EventoId = 3
                },
                new Organizador
                {
                    Id = 8,
                    Nombre = "Fernando José Ramírez",
                    Cargo = "Coordinador de Talleres",
                    EventoId = 3
                },
                new Organizador
                {
                    Id = 9,
                    Nombre = "Sofía Alexandra Morales",
                    Cargo = "Especialista en Comunicaciones",
                    EventoId = 3
                }
            );
        }
    }
}
