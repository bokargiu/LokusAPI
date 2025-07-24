using LokusAPI.Dtos;
using LokusAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LokusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupClientController : ControllerBase
    {

        private readonly ClientService _service;
        public SignupClientController(ClientService service) 
        {
            _service = service;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> ClientSignUp([FromBody] ClientDto dto)
        {
            try
            {
                var result = await _service.ClientSignUpAsync(dto);
                return Ok(result);
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
