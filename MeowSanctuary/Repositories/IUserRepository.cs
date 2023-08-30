using MeowSanctuary.Models;
using MeowSanctuary.Repositories.IGenericRepository;

namespace MeowSanctuary.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetUserByEmail(string email);
        Task<User?> GetUserByEmailAndHashedPassword(string email, string hash);
    }
}
