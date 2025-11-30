namespace GameNightTrackerAPI.Dtos;

public class GameDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
     public int MinPlayers { get; set; }
    public int MaxPlayers { get; set; } 

}