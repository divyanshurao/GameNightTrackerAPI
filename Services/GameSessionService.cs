using GameNightTrackerAPI.Data;
using GameNightTrackerAPI.Dtos;
using GameNightTrackerAPI.Models;
using GameNightTrackerAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace GameNightTrackerAPI.Services;

public class GameSessionService: IGameSession
{
    IGameSessionRepository _sessionRepository;
    IGameRepository _gameRepository;
    ApplicationDbContext _context;
    public GameSessionService(IGameSessionRepository sessionRepository, 
    IGameRepository gameRepository,
    ApplicationDbContext context)
    {
        _sessionRepository = sessionRepository;
        _gameRepository = gameRepository;
        _context = context;
    }
    
    public async Task<IEnumerable<GameSessionDto>> GetAllAsync()
    {
        var sessions = await _sessionRepository.GetAllAsync();
        return sessions.Select(ToDto);
    }
    public async Task<GameSessionDto?> GetByIdAsync(int id)
    {
        var session = await _sessionRepository.GetByIdAsync(id);
        return session == null ? null: ToDto(session);
    }
    public async Task<GameSessionDto>CreateAsync(CreateGameSessionDto createGameSessionDto)
    {
        var game = await _gameRepository.GetByIdAsync(createGameSessionDto.GameId);
        if (game == null)throw new ArgumentException("Invalid Game");

        if(createGameSessionDto.PlayersIds == null || createGameSessionDto.PlayersIds.Count==0)
        throw new ArgumentException("Atleast one player is required");

        var distinctPlayerIds = createGameSessionDto.PlayersIds.Distinct().ToList();
        var players = await _context.Players
            .Where(p=>distinctPlayerIds.Contains(p.Id))
            .ToListAsync();

        if(players.Count != distinctPlayerIds.Count)
        new ArgumentException("One or more players are invalid"); 
        
        if(createGameSessionDto.WinnerPlayerId.HasValue &&
        !distinctPlayerIds.Contains(createGameSessionDto.WinnerPlayerId.Value))
        {
            throw new ArgumentException("WinnerPlayerId must be one of the PlayerIds.");
        }

        var session = new GameSession
        {
            GameId = createGameSessionDto.GameId,
            DateOfSession = createGameSessionDto.DateOfSession ?? DateTime.Now,
            WinnerPlayerId = createGameSessionDto.WinnerPlayerId,
            Players = players
        };
        await _sessionRepository.AddAsync(session);
        await _sessionRepository.SaveAllAsync();
        
        var savedSession = await _sessionRepository.GetByIdAsync(session.Id) ?? session;
        return ToDto(session);
    }

    public async Task<bool> DeleteAsync(int id)
    {
      var session = await _sessionRepository.GetByIdAsync(id);
      if(session == null)return false;
      _sessionRepository.Delete(session);
      await _sessionRepository.SaveAllAsync();
      return true;
    }
    public static GameSessionDto ToDto(GameSession gameSession)
    {
        GameSessionDto gameSessionDto = new GameSessionDto();
        gameSessionDto.Id=gameSession.Id;
        gameSessionDto.DateOfSession=gameSession.DateOfSession;
        gameSessionDto.GameId=gameSession.GameId;
        gameSessionDto.GameName=gameSession.Game?.Name??string.Empty;
        gameSessionDto.PlayerIds=gameSession.Players.Select(p=>p.Id).ToList();
        gameSessionDto.WinnerPlayerId=gameSession.WinnerPlayerId;
        return gameSessionDto;
    }
}