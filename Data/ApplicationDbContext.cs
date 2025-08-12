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
    public DbSet<GameSession>GameSessions{ get; set; }
}