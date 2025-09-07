using LokusAPI.Dtos.AvailabilityDtos;
using LokusAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LokusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityController : ControllerBase
    {
        private readonly AvailabilityService _availabilityService;

        public AvailabilityController(AvailabilityService availabilityService)
        {
            _availabilityService = availabilityService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAvailability([FromBody] AvailabilityCreateDto dto)
        {
            try
            {
                var availability = await _availabilityService.AddAvailabilityMVP(dto);
                return Ok(availability);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("space/{spaceId}")]
        public async Task<IActionResult> GetAvailabilitiesBySpace(Guid spaceId)
        {
            var availabilities = await _availabilityService.GetAvailabilitiesBySpace(spaceId);
            return Ok(availabilities);
        }

        [HttpPatch("{availabilityId}/unavailable")]
        public async Task<IActionResult> SetUnavailable(Guid availabilityId)
        {
            try
            {
                var updated = await _availabilityService.SetUnavailable(availabilityId);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
