using MeowSanctuary.Models;
using MeowSanctuary.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace MeowSanctuary.Repositories
{
    public class CatRepository : GenericRepository<Cat>, ICatRepository
    {
        public async Task<Cat?> GetCatByName(string name)
        {
            if (name == null)
            {
                return null;
            }

            return await _context.Cats.Where(a => a.Name == name).FirstOrDefaultAsync();
        }

    }
}
