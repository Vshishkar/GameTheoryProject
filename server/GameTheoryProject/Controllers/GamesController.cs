using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameTheoryProject.Domain.Entites;
using GameTheoryProject.Domain.Services;
using GameTheoryProject.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameTheoryProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [Authorize]
        [HttpPost("")]
        public async Task<Game> Create([FromBody] CreateGameDto dto)
        {
            return await _gameService.CreateGameAsync(dto);
        }
        
        [Authorize]
        [HttpDelete("delete")]
        public async Task Delete([FromQuery] Guid gameId)
        {
            await _gameService.DeleteGameAsync(gameId);
        }
        
        [Authorize]
        [HttpGet("details")]
        public async Task<GameDetailsDto> Details([FromQuery] Guid gameId)
        {
            return await _gameService.GetGameDetailsAsync(gameId);
        }
        
        [Authorize]
        [HttpGet("")]
        public async Task<IEnumerable<GameDto>> GetList()
        {
            return await _gameService.GetAllGamesAsync();
        }
    }
}