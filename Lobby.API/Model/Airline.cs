using Microsoft.EntityFrameworkCore;

namespace AerAdvance.LobbyApi.Model;

[PrimaryKey(nameof(Id))]
public class Airline
{
    public Guid Id { get; init; } = Guid.CreateVersion7();
    public string Name { get; set; } = string.Empty;
    public string ShortCode { get; set; } = string.Empty;
    public required Guid PlayerId { get; set; }
}