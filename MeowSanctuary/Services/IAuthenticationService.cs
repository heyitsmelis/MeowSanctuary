using MeowSanctuary.Models.DTOs;
using MeowSanctuary.Models;
using MeowSanctuary.Models.Enums;

namespace MeowSanctuary.Services
{
    public interface IAuthenticationService
    {
        Task<Token?> Authenticate(UserLoginDTO? user);
        Task<User> Register(UserRegisterDTO user);
        string GenerateSalt();
        string HashPassword(string password, string salt);
        object GetById(int userId);
        object GetById(Guid userId);
    }
}
