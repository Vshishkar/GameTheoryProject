using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameTheoryProject.Database;
using GameTheoryProject.Domain.Entites;
using GameTheoryProject.Dto;
using Microsoft.EntityFrameworkCore;

namespace GameTheoryProject.Domain.Services
{
    internal class GameService : IGameService
    {
        private readonly MainDbContext _mainDbContext;

        public GameService(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task<Game> CreateGameAsync(CreateGameDto dto)
        {
            var game = new Game
            {
                Title = dto.Title,
            };

            var added = await _mainDbContext.Games.AddAsync(game);
            await _mainDbContext.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<IEnumerable<GameDto>> GetAllGamesAsync()
        {
            return await _mainDbContext.Games.Select(x => new GameDto(x.GameId, x.Title)).ToListAsync();
        }

        public async Task<GameDetailsDto> GetGameDetailsAsync(Guid gameId)
        {
            var game = await _mainDbContext.Games
                .Include(x => x.UserGameResponses).ThenInclude(x => x.User)
                .SingleOrDefaultAsync(x => x.GameId == gameId);

            if (game == null)
            {
                throw new ArgumentException("Invalid argument");
            }

            return new GameDetailsDto(
                game.GameId,
                game.Title,
                game.UserGameResponses
                    .Select(x =>
                        new PlayerDto(x.UserId, x.User.Username, x.Number))
                    .ToList());
        }

        public async Task DeleteGameAsync(Guid gameId)
        {
            var game = await _mainDbContext.Games.SingleOrDefaultAsync(x => x.GameId == gameId);

            if (game == null)
            {
                throw new ArgumentException("Invalid argument");
            }

            _mainDbContext.Games.Remove(game);
            await _mainDbContext.SaveChangesAsync();
        }
    }
}