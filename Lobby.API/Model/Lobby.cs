namespace AerAdvance.LobbyApi.Model;

public class Lobby
{
    public string LobbyName { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public bool IsPublic { get; set; } = false;
    public List<string> StarterAircraftTypes { get; set; } = new List<string>();
    public long StartingMoney { get; set; } = 100_000_000;
    public EconomyModifiers EconomyModifiers { get; set; } = new EconomyModifiers();
}