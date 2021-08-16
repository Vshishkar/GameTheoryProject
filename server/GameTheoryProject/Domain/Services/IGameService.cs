using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameTheoryProject.Domain.Entites;
using GameTheoryProject.Dto;

namespace GameTheoryProject.Domain.Services
{
    public interface IGameService
    {
        Task<Game> CreateGameAsync(CreateGameDto dto);

        Task<IEnumerable<GameDto>> GetAllGamesAsync();

        Task<GameDetailsDto> GetGameDetailsAsync(Guid gameId);

        Task DeleteGameAsync(Guid gameId);

        Task<Game> StartGame(Guid gameId);
        
        Task<Game> FinishGame(Guid gameId);
    }
}