using System;
using System.Linq;
using System.Threading.Tasks;
using GameTheoryProject.Database;
using GameTheoryProject.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace GameTheoryProject.Domain.Services
{
    internal class UserService : IUserService
    {
        private readonly MainDbContext _context;
        private readonly ITokenHandler _tokenHandler;

        public UserService(MainDbContext context, ITokenHandler tokenHandler)
        {
            _context = context;
            _tokenHandler = tokenHandler;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var added = await _context.AddAsync(user);
            return added.Entity;
        }

        public async Task<string> SignInUserAsync(string username, string password)
        {
            bool hasUsername = await _context.Users.AnyAsync(x => x.Username == username);
            if (hasUsername)
            {
                throw new ArgumentException("Invalid username");
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            var user = new User
            {
                IsAdmin = false,
                PasswordHash = passwordHash,
                Username = username
            };

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            string token = _tokenHandler.IssueTokenForUser(user);
            return token;
        }

        public async Task<string> LogInUserAsync(string username, string password)
        {
            var user = await _context.Users.SingleAsync(x => x.Username == username);
            bool verified = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
             
            if (!verified)
            {
                throw new InvalidOperationException("Can't authorize");
            }

            string token = _tokenHandler.IssueTokenForUser(user);
            return token;
        }
    }
}