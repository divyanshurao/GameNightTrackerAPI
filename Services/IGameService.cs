using GameNightTrackerAPI.Dtos;
using GameNightTrackerAPI.Models;

namespace GameNightTrackerAPI.Services;

public interface IGameService
{
    Task<IEnumerable<GameDto>> GetAllGamesAsync();
    Task<GameDto?> GetByIdAsync(int id);
    Task<GameDto> AddGameAsync(GameDto gameDto);
    Task DeleteGameAsync(int id);
}