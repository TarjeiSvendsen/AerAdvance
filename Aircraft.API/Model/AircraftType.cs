using Microsoft.EntityFrameworkCore;

namespace Aircraft.API.Model;

[PrimaryKey(nameof(Id))]
public class AircraftType
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Name { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
}