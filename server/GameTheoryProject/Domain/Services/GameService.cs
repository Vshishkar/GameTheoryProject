using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameTheoryProject.Database;
using GameTheoryProject.Domain.Entites;
using GameTheoryProject.Dto;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace GameTheoryProject.Domain.Services
{
    internal class GameService : IGameService
    {
        private readonly MainDbContext _mainDbContext;
        private IHubContext<PlayersHub, IPlayersHubService> _hubContext;

        public GameService(MainDbContext mainDbContext, IHubContext<PlayersHub, IPlayersHubService> hubContext)
        {
            _mainDbContext = mainDbContext;
            _hubContext = hubContext;
        }

        public async Task<Game> CreateGameAsync(CreateGameDto dto)
        {
            var game = new Game
            {
                Title = dto.Title,
                Status = GameStatus.Draft,
            };

            var added = await _mainDbContext.Games.AddAsync(game);
            await _mainDbContext.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<IEnumerable<GameDto>> GetAllGamesAsync()
        {
            return await _mainDbContext.Games.Select(x => new GameDto(x.GameId, x.Title, x.Status)).ToListAsync();
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
                game.Status,
                game.WinningNumber,
                game.AverageByHalf,
                game.UserGameResponses
                    .Select(x =>
                        new PlayerDto(x.UserId, x.User.Username, x.Number, x.IsWinner))
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

        public async Task<Game> StartGame(Guid gameId)
        {
            var game = await _mainDbContext.Games.SingleOrDefaultAsync(x => x.GameId == gameId);

            if (game == null)
            {
                throw new ArgumentException("Invalid argument");
            }

            game.Status = GameStatus.InProgress;
            _mainDbContext.Games.Update(game);
            await _mainDbContext.SaveChangesAsync();

            await _hubContext.Clients.All.NotifyGameStatus(GameStatus.InProgress);
            
            return game;
        }

        public async Task<Game> FinishGame(Guid gameId)
        {
            var game = await _mainDbContext.Games
                .Include(x => x.UserGameResponses)
                .SingleOrDefaultAsync(x => x.GameId == gameId);

            if (game == null)
            {
                throw new ArgumentException("Invalid argument");
            }
            
            game.Status = GameStatus.Done;
            _mainDbContext.Games.Update(game);

            int count = game.UserGameResponses.Count(x => x.Number.HasValue);
            long sum = game.UserGameResponses.Where(x => x.Number.HasValue)
                .Select(x => x.Number.Value)
                .Sum();

            if (count == 0)
            {
                throw new InvalidOperationException("Something went wrong :(");
            }
            
            double average =  (sum + 0.0) / count;
            double specialNumber = average / 2;

            var sorted = game.UserGameResponses
                .Where(x => x.Number.HasValue)
                .OrderBy(x => x.Number)
                .ToList();

            double minDist = 100;

            int winnerNumberLess = -1;
            foreach (var userGameResponse in sorted)
            {
                double dist = Math.Abs(userGameResponse.Number.Value - specialNumber);
                if (dist < minDist)
                {
                    minDist = dist;
                    winnerNumberLess = userGameResponse.Number.Value;
                }
            }

            var winners = sorted.Where(x => x.Number == winnerNumberLess);
            foreach (var winner in winners)
            {
                winner.IsWinner = true;
            }

            _mainDbContext.UserGameResponses.UpdateRange(winners);

            game.WinningNumber = winnerNumberLess;
            game.AverageByHalf = specialNumber;
            _mainDbContext.Games.Update(game);
            
            await _mainDbContext.SaveChangesAsync();
            await _hubContext.Clients.All.NotifyGameStatus(GameStatus.Done, gameId, 123);
            
            return game;
        }
    }
}