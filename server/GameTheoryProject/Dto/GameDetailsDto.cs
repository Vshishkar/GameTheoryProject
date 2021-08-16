using System;
using System.Collections.Generic;

namespace GameTheoryProject.Dto
{
    public record GameDetailsDto(Guid GameId, string GameTitle, IList<PlayerDto> Players);

    public record PlayerDto(Guid UserId, string Username, int? GameResponse);

}