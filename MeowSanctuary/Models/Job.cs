using MeowSanctuary.Models.Base;
using MeowSanctuary.Models.DTOs;

namespace MeowSanctuary.Models
{
    public class Job : BaseEntity
    {
        public Job(JobDTO job)
        {
        }

        public string Name { get; set; }
        public string Salary { get; set; }

        public ICollection<Worker> Workers { get; set; }
    }
}
