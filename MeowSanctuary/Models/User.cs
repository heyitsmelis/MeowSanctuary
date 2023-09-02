using MeowSanctuary.Models.Base;
using MeowSanctuary.Models.Enums;
using System.Data;

namespace MeowSanctuary.Models
{
    public class User : BaseEntity
    {
        private int id;
        private string hashedPassword;
        private string salt;
        private string role;

        public User(int id, string email, string hashedPassword, string salt, string role)
        {
            this.id = id;
            Email = email;
            this.hashedPassword = hashedPassword;
            this.salt = salt;
            this.role = role;
        }

        public Worker Worker { get; set; }
        public Guid WorkerId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public Role Role { get; set; } = Role.user;
    }
}
