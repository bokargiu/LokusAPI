using LokusAPI.Database;
using LokusAPI.Dtos;
using LokusAPI.Models;
using LokusAPI.Services.CompanyServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace LokusAPI.Services.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private readonly AppDb _context;

        public CompanyService(AppDb context)
        {
            _context = context;
        }

        public async Task<Company> SignUpAsync(CompanyDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                throw new Exception("Já existe um usuário com este e-mail.");

            // cria usuário
            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                Role = "company",
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // cria empresa
            var company = new Company
            {
                NameCompany = dto.NameCompany,
                Cnpj = dto.Cnpj,
                ContactOther = dto.ContactOther,
                UserId = user.Id
            };

            
            var stablishment = new Stablishment
            {
                Id = Guid.NewGuid(),
                Name = dto.NameCompany,        
                VirtualName = dto.NameCompany.ToLower().Replace(" ", "-"),
                Contact = dto.ContactOther,   
                Description = string.Empty,    
                Company = company,
                Address = new Address          
                {
                    Id = Guid.NewGuid(),
                    Road = string.Empty,
                    City = string.Empty,
                    State = string.Empty,
                    Cep = string.Empty
                }
            };

            company.Stablishments = new List<Stablishment> { stablishment };

            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            return company;
        }


    }
}
    

