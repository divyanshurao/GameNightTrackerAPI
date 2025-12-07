using GameNightTrackerAPI.Dtos;
using GameNightTrackerAPI.Models;

namespace GameNightTrackerAPI;

public interface IGameSession
{
    Task<IEnumerable<GameSessionDto>>GetAllAsync();
    Task<GameSessionDto?>GetByIdAsync(int id);
    Task<GameSessionDto>CreateAsync(CreateGameSessionDto gameSession);
    Task<bool>DeleteAsync(int id);
}
