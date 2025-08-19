using LokusAPI.Dtos;
using LokusAPI.Models;
using LokusAPI.Services.AuthServices;
using LokusAPI.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LokusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        protected readonly IAuthService _auth;
        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDtoLogin dto)
        {
            var response = await _auth.Login(dto);
            if (response != null)
            {
                return Ok(new { response });
            }
            return Unauthorized();
        }

    }
}
