using MeowSanctuary.Models.Base;

namespace MeowSanctuary.Models
{
    public class Shelter : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<Cat> Cats { get; set; }
    }
}
