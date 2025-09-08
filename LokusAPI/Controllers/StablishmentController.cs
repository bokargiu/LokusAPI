using LokusAPI.Dtos.StablishmentDto;
using System.Security.Claims;
using LokusAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace LokusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StablishmentController : ControllerBase
    {
        private readonly StablishmentService _stablishmentService;

        public StablishmentController(StablishmentService stablishmentService)
        {
            _stablishmentService = stablishmentService;
        }

        [Authorize(Roles = "Company")]
        [HttpGet("my-stablishments")]
        public async Task<ActionResult<List<StablishmentResponseDto>>> GetMyStablishments()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return Unauthorized();

            var userId = Guid.Parse(userIdClaim);
            var stablishments = await _stablishmentService.GetStablishmentsByUserIdAsync(userId);

            return Ok(stablishments);
        }
    }
}
