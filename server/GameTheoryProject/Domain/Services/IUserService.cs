using System.Threading.Tasks;
using GameTheoryProject.Domain.Entites;

namespace GameTheoryProject.Domain.Services
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(User user);

        Task<string> SignInUserAsync(string username, string password);

        Task<string> LogInUserAsync(string username, string password);
    }
}