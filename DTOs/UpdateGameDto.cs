namespace GameNightTrackerAPI.Dtos;

public class UpdateGameDto
{
    public string Name { get; set; } = string.Empty;
    public int MinPlayers { get; set; }
    public int MaxPlayers { get; set; }
}