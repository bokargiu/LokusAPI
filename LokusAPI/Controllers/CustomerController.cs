using LokusAPI.Dtos;
using LokusAPI.Models;
using LokusAPI.Services.ClientServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace LokusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        protected readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService) 
        { 
            _customerService = customerService;
        }
        [HttpPost("SingUp")]
        public async Task<IActionResult> SingUp([FromBody] SingUpClientDto dto)
        {
            try
            {
                if (dto.Password != dto.ConfirmPassword) return BadRequest("Senhas não Correspondentes!");
                Tuple<bool, string> response = await _customerService.SingUpCustomer(dto);
                if (response.Item1 == true) return Ok(response.Item2);
                else return BadRequest(response.Item2);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message,
                    stackTrace = ex.StackTrace,
                    inner = ex.InnerException?.Message,
                    deeper = ex.InnerException?.InnerException?.Message
                });
            }



        }
        [HttpGet("GetIdByUser/")]
        public async Task<IActionResult> GetCustomerId(Guid UserId)
        {
            try
            {
                var response = await _customerService.GetCustomerByUserId(UserId);
                if (response != null) return Ok(response);
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
