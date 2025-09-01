using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventoAPI.Migrations
{
    /// <inheritdoc />
    public partial class Migracion_Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lugar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizadores_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participantes_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "Id", "Fecha", "Lugar", "Nombre" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Centro de Convenciones San Salvador", "Conferencia de Tecnología 2025" },
                    { 2, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hotel Real InterContinental", "Seminario de Desarrollo Empresarial" },
                    { 3, new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Universidad Don Bosco", "Workshop de Innovación Digital" }
                });

            migrationBuilder.InsertData(
                table: "Organizadores",
                columns: new[] { "Id", "Cargo", "EventoId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Coordinadora General", 1, "Ana María García" },
                    { 2, "Director Técnico", 1, "Carlos Roberto Méndez" },
                    { 3, "Coordinadora de Logística", 1, "María Elena Rodríguez" },
                    { 4, "Director Ejecutivo", 2, "José Antonio López" },
                    { 5, "Gerente de Eventos", 2, "Patricia Isabel Martínez" },
                    { 6, "Coordinador Académico", 2, "Roberto Carlos Hernández" },
                    { 7, "Directora de Innovación", 3, "Laura Beatriz Castillo" },
                    { 8, "Coordinador de Talleres", 3, "Fernando José Ramírez" },
                    { 9, "Especialista en Comunicaciones", 3, "Sofía Alexandra Morales" }
                });

            migrationBuilder.InsertData(
                table: "Participantes",
                columns: new[] { "Id", "Email", "EventoId", "Nombre" },
                values: new object[,]
                {
                    { 1, "miguel.vasquez@email.com", 1, "Miguel Ángel Vásquez" },
                    { 2, "carmen.flores@email.com", 1, "Carmen Lucía Flores" },
                    { 3, "diego.santos@email.com", 1, "Diego Alejandro Santos" },
                    { 4, "andrea.cruz@email.com", 1, "Andrea Valentina Cruz" },
                    { 5, "sebastian.rivas@email.com", 1, "Sebastián Eduardo Rivas" },
                    { 6, "gabriela.pena@email.com", 2, "Gabriela Monserrat Peña" },
                    { 7, "alejandro.torres@email.com", 2, "Alejandro Rafael Torres" },
                    { 8, "isabella.campos@email.com", 2, "Isabella María Campos" },
                    { 9, "mauricio.jimenez@email.com", 2, "Mauricio Ernesto Jiménez" },
                    { 10, "valeria.aguilar@email.com", 2, "Valeria Stephania Aguilar" },
                    { 11, "daniel.ortega@email.com", 3, "Daniel Francisco Ortega" },
                    { 12, "natalia.molina@email.com", 3, "Natalia Esperanza Molina" },
                    { 13, "ricardo.velasco@email.com", 3, "Ricardo Mauricio Velasco" },
                    { 14, "paola.guerrero@email.com", 3, "Paola Fernanda Guerrero" },
                    { 15, "cristian.salazar@email.com", 3, "Cristian Armando Salazar" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Organizadores_EventoId",
                table: "Organizadores",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_EventoId",
                table: "Participantes",
                column: "EventoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Organizadores");

            migrationBuilder.DropTable(
                name: "Participantes");

            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
