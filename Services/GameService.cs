using AutoMapper;
using GameNightTrackerAPI.Dtos;
using GameNightTrackerAPI.Models;
using GameNightTrackerAPI.Repositories;

namespace GameNightTrackerAPI.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;
    private readonly IMapper _mapper;
    public GameService(IGameRepository gameRepository, IMapper mapper)
    {
        _gameRepository = gameRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<GameDto>> GetAllGamesAsync()
    {
        var games = await _gameRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<GameDto>>(games);
    }
    public async Task<GameDto?> GetByIdAsync(int id)
    {
        var game = await _gameRepository.GetByIdAsync(id);
        return _mapper.Map<GameDto?>(game);
    }
    public async Task<GameDto> AddGameAsync(CreateGameDto gameDto)
    {
        var game = _mapper.Map<Game>(gameDto);
        await _gameRepository.AddAsync(game);
        await _gameRepository.SaveChangesAsync();
        return _mapper.Map<GameDto>(game);
    }
    public async Task<bool>UpdateGameAsync(int id, UpdateGameDto gameDto)
    {
        var existingGame = await _gameRepository.GetByIdAsync(id);
        if(existingGame==null)return false;
        _mapper.Map(gameDto, existingGame);
        await _gameRepository.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteGameAsync(int id)
    {
        var game = await _gameRepository.GetByIdAsync(id);
        if(game==null)return false;
        _gameRepository.Delete(game);
        await _gameRepository.SaveChangesAsync(); 
        return true;
    }
}
