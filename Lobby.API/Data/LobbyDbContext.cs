using AerAdvance.LobbyApi.Model;
using Microsoft.EntityFrameworkCore;

namespace AerAdvance.LobbyApi.Data;

public class LobbyDbContext(DbContextOptions<LobbyDbContext> options): DbContext(options)
{
    public DbSet<Lobby> Lobbies { get; set; } = null!;
    public DbSet<Airline> Airlines { get; set; } = null!;

}