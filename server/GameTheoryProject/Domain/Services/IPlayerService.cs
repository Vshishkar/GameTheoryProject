using System;
using System.Threading.Tasks;
using GameTheoryProject.Dto;

namespace GameTheoryProject.Domain.Services
{
    public interface IPlayerService
    {
        Task JoinGameAsync(Guid gameId);

        Task SubmitAnswerAsync(AnswerDto answerDto);

        Task<PlayerGameDetails> GetGameDetailsAsync(Guid gameId);
        
        Task<bool> IsUserJoinedAsync(Guid gameId);
    }
}