using System;
using System.Collections.Generic;

namespace GameTheoryProject.Domain.Models
{
    public class Game
    {
        public Guid GameId { get; set; }

        public IList<UserGameResponse> UserGameResponses { get; set; }
    }
}