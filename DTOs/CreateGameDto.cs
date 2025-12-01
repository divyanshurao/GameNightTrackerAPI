namespace GameNightTrackerAPI.Dtos;

public class CreateGameDto
{
    public string Name { get; set; } = string.Empty;
    public int MinPlayers { get; set; }
    public int MaxPlayers { get; set; } 
}