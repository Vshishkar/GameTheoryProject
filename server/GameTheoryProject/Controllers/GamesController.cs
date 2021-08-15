using System.Threading.Tasks;
using GameTheoryProject.Database;
using GameTheoryProject.Domain.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameTheoryProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly MainDbContext _context;

        public GamesController(MainDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpPost]
        public async Task<Game> Create()
        {
            var game = new Game();
            var result =  await _context.Games.AddAsync(game);
            return result.Entity;
        }
    }
}