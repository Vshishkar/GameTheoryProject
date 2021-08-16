using System;

namespace GameTheoryProject.Dto
{
    public record CreateGameDto(string Title);
    
    public record GameActionDto(Guid GameId);
}