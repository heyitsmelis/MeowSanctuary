using MeowSanctuary.Models;
using MeowSanctuary.Repositories.IGenericRepository;

namespace MeowSanctuary.Repositories
{
    public interface IJobRepository : IGenericRepository<Job>
    {
        Task<Job?> GetJobByTitle(string title);
    }
}
