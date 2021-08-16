using System;

namespace GameTheoryProject.Dto
{
    public record PlayerGameDetails(string Title, int? Answer);

    public record PlayerJoinGameDto(Guid GameId);
}