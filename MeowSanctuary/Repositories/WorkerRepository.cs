using MeowSanctuary.Data;
using MeowSanctuary.Models;
using MeowSanctuary.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace MeowSanctuary.Repositories
{
    public class WorkerRepository: GenericRepository<Worker>, IWorkerRepository
    {
        public WorkerRepository(SanctuaryContext context) : base(context)
        {
        }
        public async Task<Worker?> GetWorkerByFullName(string firstName, string lastName)
        {
            if (firstName == null || lastName == null)
            {
                return null;
            }

            return await _context.Workers.Where(a => a.FirstName.ToLower().Equals(firstName.ToLower())
            && a.LastName.ToLower().Equals(lastName.ToLower())).FirstOrDefaultAsync();
        }
    }
}
