using MeowSanctuary.Data;
using MeowSanctuary.Models;
using MeowSanctuary.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MeowSanctuary.Repositories
{
    public class ShelterRepository : GenericRepository<Shelter>, IShelterRepository
    {
        public ShelterRepository(SanctuaryContext context) : base(context)
        {
        }
        public async Task<Shelter?> GetCompanyByName(string name)
        {
            return await _context.Shelters.Where(a => a.Name == name).FirstOrDefaultAsync();
        }
    }
}
