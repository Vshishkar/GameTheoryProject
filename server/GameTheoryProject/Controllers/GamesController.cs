using System.Threading.Tasks;
using GameTheoryProject.Database;
using GameTheoryProject.Domain.Models;
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

        [HttpPost]
        public async Task<Game> Create()
        {
            var game = new Game();
            var result =  await _context.Games.AddAsync(game);
            return result.Entity;
        }
    }
}