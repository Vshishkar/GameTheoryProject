using System;
using System.Collections.Generic;

namespace GameTheoryProject.Domain.Entites
{
    public class User
    {
        public Guid UserId { get; set; }
        
        public string Username { get; set; }

        public bool IsAdmin { get; set; }
        
        public string PasswordHash { get; set; }

        public IList<UserGameResponse> UserGameResponses { get; set; }
    }
}