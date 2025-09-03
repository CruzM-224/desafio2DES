using EventoAPI.Models;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Configurar DbContext con SQL Server
builder.Services.AddDbContext<EventosDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EventosCN")));

// Configurar Output Caching con Redis si la cadena de conexión está presente
var redisCnx = builder.Configuration.GetConnectionString("redis");
if (!string.IsNullOrWhiteSpace(redisCnx))
{
    builder.Services.AddStackExchangeRedisOutputCache(options =>
    {
        options.Configuration = redisCnx;
    });

    builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
    {
        var configuration = ConfigurationOptions.Parse(redisCnx, true);
        return ConnectionMultiplexer.Connect(configuration);
    });
}

builder.Services.AddOutputCache();

// Agregar controladores
builder.Services.AddControllers();

// Registrar Swagger para que el Gateway pueda usarlo
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "EventoAPI v1");
    c.RoutePrefix = "swagger";

});

//app.UseHttpsRedirection();

if (!app.Environment.IsEnvironment("Docker"))
{
    app.UseHttpsRedirection();
}

app.UseOutputCache();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EventosDbContext>();
    db.Database.Migrate(); // crea BD "Eventos" y aplica migraciones en el SQL del contenedor
}

app.Run();
