namespace GameNightTrackerAPI.Dtos;

public class GameSessionDto
{
    public int Id {get; set;}
    public DateTime DateOfSession {get; set;}

    public int GameId{get; set;}
    public string GameName{get; set;} = string.Empty;
    
     public List<int> PlayerIds { get; set; } = new();
    public int? WinnerPlayerId { get; set; } 
}