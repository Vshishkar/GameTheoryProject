using System;
using GameTheoryProject.Domain.Entites;

namespace GameTheoryProject.Dto
{
    public record GameDto(Guid GameId, string GameTitle, GameStatus Status);
}