using LokusAPI.Dtos;
using LokusAPI.Models;
using LokusAPI.Services.CompanyService;
using LokusAPI.Services.CompanyServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LokusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupCompanyController : ControllerBase {

        private readonly ICompanyService _companyService;

        public SignupCompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CompanyDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // registra novo usuário + estabelecimento
                Stablishment stablishment = await _companyService.RegisterAsync(dto);

                // retorna dados resumidos do estabelecimento recém-criado
                var response = new
                {
                    EstablishmentId = stablishment.Id,
                    stablishment.Name,
                    stablishment.VirtualName,
                    stablishment.Description,
                    stablishment.Contact,
                    CompanyId = stablishment.CompanyId,
                    Address = new
                    {
                        stablishment.Address.Road,
                        stablishment.Address.City,
                        stablishment.Address.State,
                        stablishment.Address.Cep
                    }
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
        



}
