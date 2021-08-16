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
    public class PlayerService : IPlayerService
    {
        private readonly MainDbContext _mainDbContext;
        private readonly IExecutionContextService _executionContextService;

        public PlayerService(MainDbContext mainDbContext, IExecutionContextService executionContextService)
        {
            _mainDbContext = mainDbContext;
            _executionContextService = executionContextService;
        }

        public async Task JoinGameAsync(Guid gameId)
        {
            var user = await _executionContextService.GetCurrentUserAsync();
            var game = await _mainDbContext.Games.SingleAsync(x => x.GameId == gameId);

            var userGameResponse = new UserGameResponse
            {
                Number = null,
                UserId = user.UserId,
                GameId = game.GameId
            };

            await _mainDbContext.UserGameResponses.AddAsync(userGameResponse);
            await _mainDbContext.SaveChangesAsync();
        }

        public async Task SubmitAnswerAsync(AnswerDto answerDto)
        {
            var user = await _executionContextService.GetCurrentUserAsync();
            var game = await _mainDbContext.Games.SingleAsync(x => x.GameId == answerDto.GameId);

            
            var response = await _mainDbContext.UserGameResponses
                .SingleAsync(x => x.GameId == game.GameId &&
                                  x.UserId == user.UserId);

            if (response.Number.HasValue)
            {
                throw new InvalidOperationException("Cannot submit twice");
            }
            
            response.Number = answerDto.Answer;
            
            _mainDbContext.UserGameResponses.Update(response);
            await _mainDbContext.SaveChangesAsync();
        }

        public async Task<PlayerGameDetails> GetGameDetailsAsync(Guid gameId)
        {
            var user = await _executionContextService.GetCurrentUserAsync();
            var game = await _mainDbContext.Games.SingleAsync(x => x.GameId == gameId);

            
            var response = await _mainDbContext.UserGameResponses
                .SingleAsync(x => x.GameId == game.GameId &&
                                  x.UserId == user.UserId);

            IList<GameWinner> winners = new List<GameWinner>();
            if (game.Status == GameStatus.Done)
            {
                winners =  await _mainDbContext.UserGameResponses
                    .Where(x => x.IsWinner && x.GameId == gameId)
                    .Select(x => new GameWinner(x.UserId, x.Number)).ToListAsync();
            }
            
            return new PlayerGameDetails(game.Title, game.Status, response.Number, winners);
        }

        public async Task<bool> IsUserJoinedAsync(Guid gameId)
        {
            var user = await _executionContextService.GetCurrentUserAsync();
            var game = await _mainDbContext.Games.SingleAsync(x => x.GameId == gameId);
            
            var isJoined = await _mainDbContext.UserGameResponses
                .AnyAsync(x => x.GameId == game.GameId &&
                               x.UserId == user.UserId);

            return isJoined;
        }
    }
}