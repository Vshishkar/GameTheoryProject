using System;
using System.Collections.Generic;
using GameTheoryProject.Domain.Entites;

namespace GameTheoryProject.Dto
{
    public record PlayerGameDetails(string Title, GameStatus Status, int? Answer, IList<GameWinner> Winners = default);

    public record PlayerJoinGameDto(Guid GameId);

    public record GameWinner(Guid UserId, int? Answer);
}