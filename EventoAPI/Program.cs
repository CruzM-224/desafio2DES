using EventoAPI.Models;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Configurar DbContext con SQL Server
builder.Services.AddDbContext<EventosDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EventosCN")));

//Redis
builder.Services.AddStackExchangeRedisOutputCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("redis");
});

//Add IConnectionMultiplexer
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("redis"), true);
    return ConnectionMultiplexer.Connect(configuration);
});

builder.Services.AddOutputCache();

// Agregar controladores
builder.Services.AddControllers();

// Registrar Swagger para que el Gateway pueda usarlo
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/openapi/v1.json", "EventoAPI v1");
    c.RoutePrefix = "swagger";
});

app.UseSwagger();

app.UseHttpsRedirection();

app.UseOutputCache();

app.UseAuthorization();

app.MapControllers();

app.Run();
