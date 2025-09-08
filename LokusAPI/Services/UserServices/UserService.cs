using LokusAPI.Database;
using LokusAPI.Dtos;
using LokusAPI.Models;
using LokusAPI.Services.AuthServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LokusAPI.Services.UserServices
{
    public class UserService : IUserService
    {
        protected readonly AppDb _context;
        private readonly IAuthService _auth;
        public UserService(AppDb context, IAuthService auth)
        {
            _context = context;
            _auth = auth;
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
                user.Password = _auth.HashPassword(dto.Password);
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
        public async Task<User?> ExistAndGetUser(UserDtoLogin dto)
        {
            try
            {
                User? user = await _context.Users.Where(u => u.Username == dto.User || u.Email == dto.User).FirstOrDefaultAsync();
                if (user != null) return user;
                return null;
                
            }
            catch
            {
                return null;
            }
        }
    }
}
