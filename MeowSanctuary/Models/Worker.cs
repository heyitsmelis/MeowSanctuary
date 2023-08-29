using MeowSanctuary.Models.Base;

namespace MeowSanctuary.Models
{
    public class Worker : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set;}

        public Job Job { get; set;}
        public Guid JobId { get; set; }

        public ICollection<WorkSchedule> WorkSchedules { get; set; }

        public User User { get; set; }


    }
}
