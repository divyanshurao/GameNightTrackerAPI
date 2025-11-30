using GameNightTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GameNightTrackerAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    // These will become the tables in our database
    public DbSet<Game> Games { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<GameSession> GameSessions { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Game>().HasData(
            new Game { Id = 1, Name = "Catan", MinPlayers = 3, MaxPlayers = 4 },
            new Game { Id = 2, Name = "Chess", MinPlayers = 2, MaxPlayers = 2 }
        );

        modelBuilder.Entity<Player>().HasData(
        new Player { Id = 1, Name = "Alice", Email = "alice@example.com" },
        new Player { Id = 2, Name = "Bob", Email = "bob@example.com" }
        );
    }
}