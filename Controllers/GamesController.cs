using GameNightTrackerAPI.Dtos;
using GameNightTrackerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameNightTrackerAPI.Contollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        public IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetAll()
        {
            var games = await _gameService.GetAllGamesAsync();
            return Ok(games);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GameDto>> GetbyId(int id)
        {
            var game = await _gameService.GetByIdAsync(id);
            if (game == null) return NotFound();
            return Ok(game);
        }
        [HttpPost]
        public async Task<ActionResult<GameDto>> AddGame(CreateGameDto gameDto)
        {
            var createdGame = await _gameService.AddGameAsync(gameDto);
            return CreatedAtAction(nameof(GetbyId), new { id = createdGame.Id }, createdGame);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateGame(int id,[FromBody]UpdateGameDto gameDto)
        {
            var updated = await _gameService.UpdateGameAsync(id, gameDto);
            if(!updated)return NotFound();
            return NoContent(); //204
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _gameService.DeleteGameAsync(id);
            if(!deleted)return NotFound();
            return NoContent();
        }
    }
}