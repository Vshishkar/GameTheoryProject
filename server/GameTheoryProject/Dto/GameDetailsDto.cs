using System;
using System.Collections.Generic;
using GameTheoryProject.Domain.Entites;

namespace GameTheoryProject.Dto
{
    public record GameDetailsDto(Guid GameId, string GameTitle, GameStatus Status, int? WinningNumber, double? AverageByHalf, IList<PlayerDto> Players);

    public record PlayerDto(Guid UserId, string Username, int? GameResponse, bool IsWinner);

}