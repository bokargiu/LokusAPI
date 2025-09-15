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
    public class CompanyController : ControllerBase {

        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] CompanyDto dto)
        {
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                try
                {
                    // cria empresa + stablishment inicial
                    Company company = await _companyService.SignUpAsync(dto);

                    var response = new
                    {
                        Company = new
                        {
                            company.Id,
                            company.NameCompany,
                            company.Cnpj,
                            company.ContactOther
                        },
                        Stablishments = company.Stablishments.Select(s => new
                        {
                            s.Id,
                            s.Name,
                            s.VirtualName,
                            s.Contact,
                            s.Description,
                            s.CompanyId
                        })
                    };

                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(new
                    {
                        message = ex.Message,
                        inner = ex.InnerException?.Message,
                        stack = ex.StackTrace
                    });
                }
            }
        }

    }
        



}
