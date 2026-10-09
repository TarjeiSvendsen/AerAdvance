using Microsoft.EntityFrameworkCore;

namespace AerAdvance.LobbyApi.Model;

[PrimaryKey(nameof(Id))]
public class Lobby
{
    public Guid Id { get; init; } = Guid.CreateVersion7();
    public string LobbyName { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public bool IsPublic { get; set; } = false;
    public List<string> StarterAircraftTypes { get; set; } = new();
    public long StartingMoney { get; set; } = 100_000_000;
    public EconomyModifiers EconomyModifiers { get; set; } = new();
    public List<Guid> Airlines { get; set; } = new();
}