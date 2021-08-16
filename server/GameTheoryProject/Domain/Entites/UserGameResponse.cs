using System;

namespace GameTheoryProject.Domain.Entites
{
    public class UserGameResponse
    {
        public Guid GameId { get; set; }
        
        public Guid UserId { get; set; }

        public Game Game { get; set; }

        public User User { get; set; }

        public int? Number { get; set; }
    }
}