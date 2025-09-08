using LokusAPI.Dtos;
using LokusAPI.Models;

namespace LokusAPI.Services.ClientServices
{
    public interface ICustomerService
    {
        Task<Tuple<bool, string>> SingUpCustomer(SingUpClientDto dto);
        Task<Guid?> GetCustomerByUserId(Guid userID);
        Task<Customer?> GetCustomerById(Guid customerId);
    }
}
