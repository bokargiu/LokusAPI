using LokusAPI.Database;
using LokusAPI.Dtos;
using LokusAPI.Models;
using LokusAPI.Services.CompanyServices;
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

        public async Task<Stablishment> RegisterAsync(CompanyDto dto)
        {

            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                throw new Exception("Já existe um usuário com este e-mail.");


            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                Role = "Company",
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

  
            var company = await _context.Companies
                .Include(c => c.Stablishments)
                .FirstOrDefaultAsync(c => c.Cnpj == dto.Cnpj);

            if (company == null)
            {

                company = new Company
                {
                    NameCompany = dto.NameCompany,
                    Cnpj = dto.Cnpj,
                    ContactOther = dto.ContactOther,
                    UserId = user.Id
                };
                _context.Companies.Add(company);
                await _context.SaveChangesAsync();
            }



            Stablishment? lastCreated = null;

            foreach (var sDto in dto.Stablishments)
            {
                var stablishment = new Stablishment
                {
                    Name = sDto.Name,
                    VirtualName = sDto.VirtualName,
                    Description = sDto.Description,
                    Contact = sDto.Contact,
                    CompanyId = company.Id,
                    Address = new Address
                    {
                        Road = sDto.Address.Road,
                        City = sDto.Address.City,
                        State = sDto.Address.State,
                        Cep = sDto.Address.Cep
                    }
                };

                _context.Stablishments.Add(stablishment);
                lastCreated = stablishment;
            }

            await _context.SaveChangesAsync();


            return lastCreated!;
        }
    }
    
}
