using GameNightTrackerAPI.Models;

namespace GameNightTrackerAPI.Repositories;

public interface IGameSessionRepository
{
    Task<IEnumerable<GameSession>>GetAllAsync();
    Task<GameSession?>GetByIdAsync(int id);
    Task AddAsync(GameSession gameSession);
    void Delete(GameSession gameSession);
    Task SaveAllAsync();
}