using MeowSanctuary.Models.Base;

namespace MeowSanctuary.Models
{
    public class Cat : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }

        public ICollection<WorkSchedule> WorkSchedules { get; set; }

        public Shelter Shelter { get; set; }
        public Guid ShelterId { get; set; }

    }
}
