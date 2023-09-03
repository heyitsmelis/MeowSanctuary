using MeowSanctuary.Data;
using MeowSanctuary.Models;
using MeowSanctuary.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace MeowSanctuary.Repositories
{
    public class CatRepository : GenericRepository<Cat>, ICatRepository
    {
        public CatRepository(SanctuaryContext context) : base(context)
        {
        }

        public async Task<Cat?> GetCatByName(string name)
        {
            if (name == null)
            {
                return null;
            }

            return await _context.Cats.Where(a => a.Name == name).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cat>> GetAllWithInclude()
        {
            return await _context.Cats.Include(a => a.Name).ToListAsync();
        }

        public Task GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
