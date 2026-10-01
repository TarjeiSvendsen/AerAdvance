using Aircraft.API.Data;
using Aircraft.API.Repository;
using Aircraft.API.Seeding;
using Aircraft.API.Service;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add environment variables.
if (File.Exists("../.env"))
{
 DotNetEnv.Env.Load("../.env");
}

// MongoDB config
var connectionString = $"mongodb://"
                       + $"{Environment.GetEnvironmentVariable("MONGODB_HOST")}:"
                       + $"{Environment.GetEnvironmentVariable("MONGODB_PORT")}";

builder.Services.AddSingleton<IMongoClient>(
 new MongoClient(connectionString)
);

builder.Services.AddDbContext<AircraftDbContext>((serviceProvider, options) =>
{
 var mongoClient = serviceProvider.GetRequiredService<IMongoClient>();
 options.UseMongoDB(mongoClient, "aircraft");
});

builder.Services.AddScoped<IAircraftTypeRepository, AircraftTypeRepository>();
builder.Services.AddScoped<AircraftTypeService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

using var scope = app.Services.CreateScope();
var typeService = scope.ServiceProvider.GetRequiredService<AircraftTypeService>();
var typeSeeder = new AircraftTypeSeeder(typeService);

await typeSeeder.ImportAll();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();