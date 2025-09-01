using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;

var builder = WebApplication.CreateBuilder(args);

// Cargar configuraci�n de Ocelot
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Registrar Ocelot con cache
builder.Services.AddOcelot(builder.Configuration)
                .AddCacheManager(x => x.WithDictionaryHandle());

// Registrar rate limiting
builder.Services.AddRateLimiting();

var app = builder.Build();

// Ocelot debe ser lo �ltimo
await app.UseOcelot();

app.Run();
