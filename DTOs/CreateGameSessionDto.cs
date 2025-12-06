using GameNightTrackerAPI.Models;

namespace GameNightTrackerAPI.Dtos;

public class CreateGameSessionDto
{
   public int GameId{get; set;}
   public List<int>PlayersIds {get; set;}=new();
   public int? WinnerPlayerId{get; set;}

   public DateTime? DateOfSeassion {get; set;}
}