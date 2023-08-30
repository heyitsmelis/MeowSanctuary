using MeowSanctuary.Models;
using MeowSanctuary.Repositories.IGenericRepository;

namespace MeowSanctuary.Repositories
{
    public interface IWorkerRepository: IGenericRepository<Worker>
    {
        Task<Worker?> GetWorkerByFullName(string firstName, string lastName);
    }
}
