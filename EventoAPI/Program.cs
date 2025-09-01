using EventoAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar DbContext con SQL Server
builder.Services.AddDbContext<EventosDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EventosCN")));

// Agregar controladores
builder.Services.AddControllers();

// Registrar Swagger para que el Gateway pueda usarlo
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
