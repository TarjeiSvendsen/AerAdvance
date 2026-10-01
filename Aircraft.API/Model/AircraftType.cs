using Microsoft.EntityFrameworkCore;

namespace Aircraft.API.Model;

[PrimaryKey(nameof(Icao))]
public class AircraftType
{
    public string Icao { get; set; } = string.Empty;
    
    public string? Iata { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
}