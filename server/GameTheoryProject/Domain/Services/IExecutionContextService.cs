using System.Threading.Tasks;
using GameTheoryProject.Domain.Entites;

namespace GameTheoryProject.Domain.Services
{
    public interface IExecutionContextService
    {
        Task<User> GetCurrentUserAsync();
    }
}