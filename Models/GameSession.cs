using System.ComponentModel.DataAnnotations.Schema;

namespace GameNightTrackerAPI.Models;

public class GameSession
{
    public int Id { get; set; }
    public DateTime DateOfSession { get; set; }

    // Foreign Key for Game
    public int GameId { get; set; }
    [ForeignKey("GameId")]
    public Game? Game { get; set; }

    // Foreign Key for the Winner
    public int? WinnerPlayerId { get; set; } // Nullable if there's no winner
    [ForeignKey("WinnerPlayerId")]
    public Player? Winner { get; set; }

    // This defines a many-to-many relationship
    public ICollection<Player> Players { get; set; } = new List<Player>();  
}