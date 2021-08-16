using System;
using System.Threading.Tasks;
using GameTheoryProject.Domain.Entites;
using Microsoft.AspNetCore.SignalR;

namespace GameTheoryProject
{
    public interface IPlayersHubService
    {
        Task NotifyGameStatus(GameStatus status, Guid winnerId = default, int winnerNumber = default);
    }
    
    public class PlayersHub : Hub<IPlayersHubService>
    {
    }
}