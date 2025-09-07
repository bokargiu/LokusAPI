using LokusAPI.Dtos;
using LokusAPI.Models;

namespace LokusAPI.Services.CompanyServices
{
    public interface ICompanyService
    {
        Task<Stablishment> RegisterAsync(CompanyDto dto);
    }
}
