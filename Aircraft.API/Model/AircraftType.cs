using Microsoft.EntityFrameworkCore;

namespace Aircraft.API.Model;

[PrimaryKey(nameof(Id))]
public class AircraftType
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Icao { get; set; } = string.Empty;
    
    public string? Iata { get; set; } = string.Empty;
    public string Model { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Manufacturer { get; init; } = string.Empty;

    public string BodyType { get; init; } = string.Empty;

}