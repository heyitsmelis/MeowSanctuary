using MeowSanctuary.Models;
using MeowSanctuary.Repositories.IGenericRepository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MeowSanctuary.Repositories
{
    public interface IShelterRepository : IGenericRepository<Shelter>
    {
        Task<Shelter?> GetCompanyByName(string name);
    }
}
