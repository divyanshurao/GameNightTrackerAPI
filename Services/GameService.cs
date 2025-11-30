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
    public async Task<GameDto> AddGameAsync(GameDto gameDto)
    {
        var game = _mapper.Map<Game>(gameDto);
        await _gameRepository.AddAsync(game);
        await _gameRepository.SaveChangesAsync();
        return _mapper.Map<GameDto>(game);
    }
    public async Task DeleteGameAsync(int id)
    {
        var game = await _gameRepository.GetByIdAsync(id);
        if (game != null)
        {
            _gameRepository.Delete(game);
            await _gameRepository.SaveChangesAsync(); 
        }
    }
}
