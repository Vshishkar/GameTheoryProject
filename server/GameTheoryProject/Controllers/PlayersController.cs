using System;
using System.Threading.Tasks;
using GameTheoryProject.Domain.Services;
using GameTheoryProject.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GameTheoryProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet("game/is-joined")]
        public async Task<WebResponse<bool>> IsJoined([FromQuery] Guid gameId)
        {
            var isJoined = await _playerService.IsUserJoinedAsync(gameId);
            return new WebResponse<bool>
            {
                Data = isJoined,
                Success = true
            };
        }
        
        [HttpGet("game/details")]
        public async Task<PlayerGameDetails> Details([FromQuery] Guid gameId)
        {
            return await _playerService.GetGameDetailsAsync(gameId);
        }
        
        [HttpPost("game/join")]
        public async Task JoinGame([FromBody] PlayerJoinGameDto dto)
        {
            await _playerService.JoinGameAsync(dto.GameId);
        }

        [HttpPost("game/submit")]
        public async Task Submit([FromBody] AnswerDto dto)
        {
            await _playerService.SubmitAnswerAsync(dto);
        }
    }
}