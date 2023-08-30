using MeowSanctuary.Data;
using MeowSanctuary.Models;
using MeowSanctuary.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace MeowSanctuary.Repositories
{
    public class JobRepository: GenericRepository<Job>, IJobRepository
    {
        public JobRepository(SanctuaryContext context) : base(context)
        {
        }
        public async Task<Job?> GetJobByTitle(string title)
        {
            return await _context.Jobs.FirstOrDefaultAsync(job => job.Name.ToLower() == title.ToLower());
        }
    }
}
