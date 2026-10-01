namespace Aircraft.API.DTO;

public class PublicAircraftTypeDto
{
    public string Icao { get; set; } = string.Empty;
    public string? Iata { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
}