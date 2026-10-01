using Aircraft.API.Model;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Aircraft.API.Data;

public class AircraftDbContext(DbContextOptions<AircraftDbContext> options): DbContext(options)
{
    public DbSet<AircraftType> AircraftTypes { get; init; } = null!;
    
    public static AircraftDbContext Create(IMongoDatabase database) =>
        new(new DbContextOptionsBuilder<AircraftDbContext>()
            .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
            .Options);
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<AircraftType>().ToCollection("aircraft_types");
    }
}