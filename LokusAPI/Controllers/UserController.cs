using LokusAPI.Dtos;
using LokusAPI.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LokusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userService.GetUsersAsync());
        }

        [HttpGet("id:{id:guid}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
        [HttpPost("Add")]
        //[Authorize(Policy = "Admin")]
        public async Task<IActionResult> AddUser([FromBody] UserDto dto)
        {
            return Ok( await _userService.AddUserAsync(dto));
        }



    }
}
