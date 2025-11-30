using GameNightTrackerAPI.Models;
namespace GameNightTrackerAPI.Repositories
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAllAsync();
        Task<Game?> GetByIdAsync(int id);
        Task AddAsync(Game game);
        void Delete(Game game);
        Task SaveChangesAsync();
    }
}