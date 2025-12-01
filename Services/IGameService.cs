using GameNightTrackerAPI.Dtos;
using GameNightTrackerAPI.Models;

namespace GameNightTrackerAPI.Services;

public interface IGameService
{
    Task<IEnumerable<GameDto>> GetAllGamesAsync();
    Task<GameDto?> GetByIdAsync(int id);
    Task<GameDto> AddGameAsync(CreateGameDto gameDto);
    Task<bool>UpdateGameAsync(int id, UpdateGameDto updateDto);
    Task<bool>DeleteGameAsync(int id);
}