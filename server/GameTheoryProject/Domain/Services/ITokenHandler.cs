using GameTheoryProject.Domain.Entites;

namespace GameTheoryProject.Domain.Services
{
    public interface ITokenHandler
    {
        string IssueTokenForUser(User user);
    }
}