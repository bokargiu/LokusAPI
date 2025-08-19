using LokusAPI.Dtos;
using LokusAPI.Models;

namespace LokusAPI.Services.UserServices
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
        Task<User?> GetUserByIdAsync(Guid Id);
        Task<string> AddUserAsync(UserDto dto);
        Task<User?> ExistAndGetUser(UserDtoLogin dto);
    }
}
