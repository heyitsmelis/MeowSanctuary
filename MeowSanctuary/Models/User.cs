using MeowSanctuary.Models.Base;
using MeowSanctuary.Models.Enums;
using System.Data;

namespace MeowSanctuary.Models
{
    public class User : BaseEntity
    {
        public Worker Worker { get; set; }
        public Guid WorkerId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public Role Role { get; set; } = Role.user;
    }
}
