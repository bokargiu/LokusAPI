using BCrypt.Net;
using LokusAPI.Database;
using LokusAPI.Dtos;
using LokusAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LokusAPI.Services.ClientServices
{
    public class CostumerService
    {
        private readonly AppDb _context;

        public CostumerService(AppDb context)
        {
            _context = context;
        }

        public async Task<string> ClientSignUpAsync(CustomerDto dto)
        {
            bool userExist = await _context.Clients.AnyAsync(c => c.User.Email == dto.Email || c.User.Username == dto.Username);

            if (userExist)
                throw new ApplicationException("Usuário ou Email não cadastrado!");

            // cria novo cliente
            var newClient = new Customer
            {

                Name = dto.nomeCompleto,
                Cpf = dto.CPF,
                Contact = dto.Contato,
                Birthday = DateOnly.FromDateTime(dto.dataNascimento),
                User = new User
                {

                    Username = dto.Username,
                    Email = dto.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                    Role = "Cliente"
                }
            };


            _context.Users.Add(newClient.User);
            _context.Clients.Add(newClient);
            await _context.SaveChangesAsync();

            return "Cadastro realizado com sucesso!";

        }
    }
}
