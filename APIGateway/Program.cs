using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;
using MMLib.SwaggerForOcelot;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 1) Lee ocelot.json
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// 2) Requeridos por Swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Gateway", Version = "v1" });
});

// 3) Ocelot + cache + rate limit
builder.Services.AddOcelot(builder.Configuration)
                .AddCacheManager(x => x.WithDictionaryHandle());
builder.Services.AddRateLimiting();

// 4) SwaggerForOcelot (usa SwaggerEndPoints del ocelot.json)
builder.Services.AddSwaggerForOcelot(builder.Configuration);

var app = builder.Build();

// (opcional) raíz amigable
app.MapGet("/", () => Results.Ok("API Gateway is running"));

// 5) UI del gateway en /swagger
app.UseSwaggerForOcelotUI(opt =>
{
    opt.PathToSwaggerGenerator = "/swagger/docs";
});

// 6) Ocelot al final
await app.UseOcelot();
app.Run();
