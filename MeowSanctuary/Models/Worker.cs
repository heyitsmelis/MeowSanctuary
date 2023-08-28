using MeowSanctuary.Models.Base;

namespace MeowSanctuary.Models
{
    public class Worker : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string? Email {get; set;}
        public string Age { get; set;}

    }
}
