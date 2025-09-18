using LokusAPI.Database;
using LokusAPI.Dtos;
using LokusAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;

namespace LokusAPI.Services.ClientServices
{
    public class CustomerService : ICustomerService
    {
        protected readonly AppDb _context;
        public CustomerService(AppDb context)
        {
            _context = context;
        }

        public async Task<Tuple<bool, string>> SignUpCustomer(SingUpClientDto dto)
        {
            try
            {
                User user = new User(dto.Username, dto.Password, dto.Email, "customer");
                Customer customer = new Customer();
                customer.Name = dto.Name;
                customer.Cpf = dto.Cpf;
                customer.Contact = dto.Contact;
                customer.DateOfBirth = dto.DateOfBirth;
                customer.User = user;
                await _context.Users.AddAsync(user);
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
                return new Tuple<bool, string>(true, "Criado com Sucesso!");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, ex.Message); ;
            }
        }
        public async Task<Guid?> GetCustomerByUserId(Guid userID)
        {
            try
            {
                Customer? customer = await _context.Customers
                                    .Where(c => c.User.Id.Equals(userID))
                                    .FirstOrDefaultAsync();
                if (customer != null)  return customer.Id;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public async Task<Customer?> GetCustomerById(Guid customerId)
        {
            Customer? client = await _context.Customers.Where(c => customerId == c.Id).FirstOrDefaultAsync();
            if (client == null) return null;
            return client;
        }
    }
}
