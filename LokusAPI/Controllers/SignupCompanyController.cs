using LokusAPI.Dtos;
using LokusAPI.Services.CompanyService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LokusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupCompanyController : ControllerBase
    {
        private readonly CompanyService _service;

        public SignupCompanyController(CompanyService service) 
        {
            _service = service;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> CompanySignUp([FromBody] CompanyDto dto)
        {
            try
            {
                var result = await _service.CompanySignUpAsync(dto);
                return Ok(new { mensagem = result });
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno do servidor: " + ex.Message);
            }
        }
    }
}
