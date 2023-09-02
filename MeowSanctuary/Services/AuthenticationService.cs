using MeowSanctuary.Models.DTOs;
using MeowSanctuary.Models.Enums;
using MeowSanctuary.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using MeowSanctuary.Repositories;

namespace MeowSanctuary.Services
{
    public class AuthenticationService
    {
        private readonly IUserRepository _userrepo;
        private readonly IConfiguration _configuration;

        public AuthenticationService(IUserRepository userrepo, IConfiguration configuration)
        {
            _userrepo = userrepo;
            _configuration = configuration;
        }
        public async Task<Token?> Authenticate(UserLoginDTO? user)
        {
            if (user == null || user.Email == null || user.Password == null
                || user.Email == "" || user.Password == "")
            {
                throw new Exception("You must provide an email and password");
            }

            var userInDb = await _userrepo.GetUserByEmail(user.Email);
            if (userInDb == null)
            {
                throw new Exception("User doesn't exist");
            }

            string salt = userInDb.PasswordSalt;
            string hashedPassword;
            if (salt != null)
            {
                hashedPassword = HashPassword(user.Password, salt);
            }
            else return null;

            userInDb = await _userrepo.GetUserByEmailAndHashedPassword(user.Email, hashedPassword);

            if (userInDb == null)
            {
                throw new Exception("Incorrect password");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, userInDb.Email),
                    new Claim(ClaimTypes.Role, userInDb.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"]
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            //var refreshToken = GenerateRefreshToken();
            //SetRefreshToken(refreshToken);
            return new Token { TokenString = tokenHandler.WriteToken(token) };
        }


        public async Task<User> Register(UserRegisterDTO user)
        {
            if (user == null || user.Email == "" || user.Password == ""
                || user.Email == null || user.Password == null)
            {
                throw new Exception("Must enter an email and password");
            }

            if (user.Role.ToLower() != "admin" && user.Role.ToLower() != "user")
            {
                throw new Exception("Role must be admin or user");
            }

            var userInDb = await _userrepo.GetUserByEmail(user.Email);

            if (userInDb != null)
            {
                throw new Exception("User with this email already exists");
            }

            int id = user.EmployeeId;
            string email = user.Email;
            string salt = GenerateSalt();
            string hashedPassword = HashPassword(user.Password, salt);
            string role = user.Role;

            User newUser = new(id, email, hashedPassword, salt, role);
            return newUser;
        }

        public string HashPassword(string password, string salt)
        {
            byte[] saltByte = Convert.FromBase64String(salt);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltByte,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 32));

            return hashed;
        }
        public string GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }

        public object GetById(int userId)
        {
            var user = _userrepo.GetById(userId);
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}
