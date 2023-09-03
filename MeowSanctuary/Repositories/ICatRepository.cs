using MeowSanctuary.Models;
using MeowSanctuary.Repositories.IGenericRepository;

namespace MeowSanctuary.Repositories
{
    public interface ICatRepository : IGenericRepository<Cat>
    {
        Task GetById(Guid id);
        Task<Cat?> GetCatByName(string name);
    }
}
