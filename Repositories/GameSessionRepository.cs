using GameNightTrackerAPI.Data;
using GameNightTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GameNightTrackerAPI.Repositories;

public class GameSessionRepository : IGameSessionRepository
{
    private readonly ApplicationDbContext _dbContext;
    public GameSessionRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<GameSession>> GetAllAsync()
    {
        return await _dbContext.GameSessions
        .Include(gs=>gs.Game)
        .Include(gs=>gs.Players)
        .ToListAsync();
    }
    public async Task<GameSession?>GetByIdAsync(int id)
    {
        return await _dbContext.GameSessions
        .Include(gs=>gs.Game)
        .Include(gs=>gs.Players)
        .FirstOrDefaultAsync(gs=>gs.Id==id);
    }
    public async Task AddAsync(GameSession gameSession)
    {
        await _dbContext.GameSessions.AddAsync(gameSession);
    }
    public void Delete(GameSession gameSession)
    {
        _dbContext.GameSessions.Remove(gameSession);
    }

    public async Task SaveAllAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
} 