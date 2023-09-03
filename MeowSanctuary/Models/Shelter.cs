using MeowSanctuary.Models.Base;
using MeowSanctuary.Models.DTOs;

namespace MeowSanctuary.Models
{
    public class Shelter : BaseEntity
    {
        public Shelter(ShelterDTO shelter)
        {
        }

        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<Cat> Cats { get; set; }
    }
}
