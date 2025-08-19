
using LokusAPI.Dtos;
using LokusAPI.Models;

namespace LokusAPI.Services.AuthServices
{
    public interface IAuthService
    {
        string GenerateJwt(User user);
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
        Task<string?> Login(UserDtoLogin dto);
    }
}
