using System.Text.Json.Serialization;

namespace AerAdvance.ServiceDefaults.Dto.Lobby;

public class LobbyCreationDto
{
    [JsonPropertyName("lobbyName")]
    public string LobbyName { get; set; } = string.Empty;
    [JsonPropertyName("description")]
    public string? Description { get; set; } = string.Empty;
    
    [JsonPropertyName("isPublic")] public bool IsPublic { get; set; } = false;
    
    [JsonPropertyName("starterAircraft")] 
    public List<string> StarterAircraftTypes { get; set; } = new ();
    [JsonPropertyName("starterAircraftAmount")]
    public int StarterAircraftAmount { get; set; } = 1;
    
    [JsonPropertyName("startingMoney")] public long StartingMoney { get; set; } = 100_000_000;

    [JsonPropertyName("economyModifiers")]
    public EconomyModifiersDto EconomyModifiers { get; set; } = new ();
    
    public class EconomyModifiersDto
    {
        [JsonPropertyName("moneyEarnedMulti")]
        public sbyte MoneyEarnedMultiplier { get; set; } = 1;
        [JsonPropertyName("maintenanceCostMulti")]
        public sbyte MaintenanceCostMultiplier { get; set; } = 1;
        [JsonPropertyName("aircraftCostMulti")]
        public sbyte AircraftCostMultiplier { get; set; } = 1;
    }
}