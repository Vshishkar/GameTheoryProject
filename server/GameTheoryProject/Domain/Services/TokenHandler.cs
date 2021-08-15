using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GameTheoryProject.Domain.Entites;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GameTheoryProject.Domain.Services
{
    internal class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string IssueTokenForUser(User user)
        {
            var key = _configuration["Jwt:Key"];
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("isAdmin", user.IsAdmin.ToString()),
                new Claim("userId", user.UserId.ToString()),
            };
            
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));        
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);           
            var tokenDescriptor = new JwtSecurityToken("none", "none", claims, 
                expires: DateTime.Now.AddMinutes(60), signingCredentials: credentials);        
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}