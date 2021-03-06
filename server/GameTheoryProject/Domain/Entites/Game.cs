using System;
using System.Collections.Generic;

namespace GameTheoryProject.Domain.Entites
{
    public class Game
    {
        public Guid GameId { get; set; }

        public string Title { get; set; }
        
        public GameStatus Status { get; set; }

        public IList<UserGameResponse> UserGameResponses { get; set; }

        public int? WinningNumber { get; set; }

        public double? AverageByHalf { get; set; }
    }
}