using System;
using System.Linq;
using System.Threading.Tasks;
using GameTheoryProject.Database;
using GameTheoryProject.Domain.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GameTheoryProject.Domain.Services
{
    internal class ExecutionContextService : IExecutionContextService
    {
        private readonly MainDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExecutionContextService(MainDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<User> GetCurrentUserAsync()
        {
            if (_httpContextAccessor.HttpContext == null)
            {
                return null;
            }
            
            string userId = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(x => x.Type == "userId")?.Value;

            if (userId == null)
            {
                return null;
            }
            
            Guid userGuid = new Guid(userId);

            return await _context.Users.SingleAsync(x => x.UserId == userGuid);
        }
    }
}