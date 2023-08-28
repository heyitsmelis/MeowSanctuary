using MeowSanctuary.Models.Base;

namespace MeowSanctuary.Models
{
    public class Job : BaseEntity
    {
        public string Name { get; set; }
        public string Salary { get; set; }

        public ICollection<Worker> Workers { get; set; }
    }
}
