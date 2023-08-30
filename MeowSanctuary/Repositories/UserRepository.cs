using MeowSanctuary.Data;
using MeowSanctuary.Models;
using MeowSanctuary.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace MeowSanctuary.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SanctuaryContext context) : base(context) { }
        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.Where(a => a.Email == email).FirstOrDefaultAsync();
        }
        public async Task<User?> GetUserByEmailAndHashedPassword(string email, string hash)
        {
            return await _context.Users.Where(a => a.Email == email &&
            a.PasswordHash == hash).FirstOrDefaultAsync();
        }

    }
}
