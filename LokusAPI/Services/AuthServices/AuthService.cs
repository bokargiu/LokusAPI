using LokusAPI.Database;
using LokusAPI.Dtos;
using LokusAPI.Models;
using LokusAPI.Services.UserServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LokusAPI.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        protected readonly IConfiguration _config;
        protected readonly AppDb _Db;
        public AuthService(IConfiguration config, AppDb Db)
        {
            _config = config;
            _Db = Db;
        }
        public string GenerateJwt(User user)
        {
            var settings = _config.GetSection("Jwt");
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                        new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role)
                    }),
                Expires = DateTime.UtcNow.AddDays(3),
                Issuer = settings["Issuer"],
                Audience = settings["Audience"],
                SigningCredentials = new SigningCredentials(
                                         new SymmetricSecurityKey(Encoding
                                                                    .UTF8
                                                                    .GetBytes(settings["Key"])),
                                         SecurityAlgorithms.HmacSha256Signature
                                         )
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
        public async Task<string?> Login(UserDtoLogin dto)
        {
            User? user = await _Db.Users.Where(u => u.Username == dto.Username || u.Email == dto.Username).FirstOrDefaultAsync();
            if (user != null && VerifyPassword(dto.Password, user.Password))
            {
                var token = GenerateJwt(user);
                return token;
            }
            return null;

        }
    }
}
