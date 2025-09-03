using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;
using MMLib.SwaggerForOcelot;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Cargar configuración de Ocelot
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Gateway", Version = "v1" });
});

// Registrar Ocelot con cache
builder.Services.AddOcelot(builder.Configuration)
                .AddCacheManager(x => x.WithDictionaryHandle());

// Registrar rate limiting
builder.Services.AddRateLimiting();

//Swashbuckle(necesario para el UI de SwaggerForOcelot)
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Gateway", Version = "v1" });
});

builder.Services.AddSwaggerForOcelot(builder.Configuration);

var app = builder.Build();

app.UseSwaggerForOcelotUI(opt =>
{
    opt.PathToSwaggerGenerator = "/swagger/docs"; // default de SwaggerForOcelot
});


// Ocelot debe ser lo último
await app.UseOcelot();

app.Run();
