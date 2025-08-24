using LokusAPI.Database;
using LokusAPI.Dtos;
using LokusAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LokusAPI.Services.CompanyService
{
    public class CompanyService
    {
        private readonly AppDb _context;

        public CompanyService(AppDb context)
        {
            _context = context;
        }

        public async Task<string> CompanySignUpAsync(CompanyDto dto)
        {
            bool userExist = await _context.Companys.AnyAsync(u => u.User.Email == dto.Email || u.User.Username == dto.Username);
            
            if (userExist)
                throw new ApplicationException("Usuário ou Email já cadastrado!");

            // creates a new company
            var newCompany = new Company
            {
                NameCompany = dto.NameCompany,
                Cnpj = dto.Cnpj,
                ContactOther = dto.ContactOther,
                User = new User
                {
                    Username = dto.Username,
                    Email = dto.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                    Role = "Empresa"
                }
            };

            _context.Users.Add(newCompany.User);
            _context.Companys.Add(newCompany);
            await _context.SaveChangesAsync();
            return "Cadastro realizado com sucesso!";
        }
    }
}
