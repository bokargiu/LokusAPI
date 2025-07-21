using LokusAPI.Database;
using LokusAPI.Dtos;
using LokusAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LokusAPI.Services.UserServices
{
    public class UserService : IUserService
    {
        protected readonly AppDb _context;
        public UserService(AppDb context)
        {
            _context = context;
        }
        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User?> GetUserByIdAsync(Guid Id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == Id);
        }
        public async Task<string> AddUserAsync(UserDto dto)
        {
            try
            {
                User user = new User();
                user.Username = dto.Username;
                user.Email = dto.Email;
                user.Password = dto.Password;
                user.Role = dto.Role;
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return $"{user.Username} foi Adicionado com Sucesso!!";
            }
            catch
            {
                return "Ocorreu um Erro!";
            }
        }
        public async Task<UserDto?> ExistAndGetUser(UserDtoLogin dto)
        {
            try
            {
                var user = await _context.Users.Where(u => u.Username == dto.Username || u.Email == dto.Username).FirstOrDefaultAsync();
                if (user != null && user.Password == dto.Password) return new UserDto(user.Username,
                                                                                      user.Email,
                                                                                      user.Password,
                                                                                      user.Role);
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
