using GameNightTrackerAPI.Data;
using GameNightTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GameNightTrackerAPI.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _context;
        public GameRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _context.Games.ToListAsync();
        }
        public async Task<Game?> GetByIdAsync(int id)
        {
            return await _context.Games.FindAsync(id);
        }
        public async Task AddAsync(Game game)
        {
            await _context.Games.AddAsync(game);
        }
        public void Delete(Game game)
        {
            _context.Games.Remove(game);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
