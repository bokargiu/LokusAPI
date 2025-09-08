using LokusAPI.Dtos.SpaceDto;
using LokusAPI.Dtos.SpaceDtos;
using LokusAPI.Dtos.SpaceDtos.SpaceDto;
using LokusAPI.Models;
using LokusAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LokusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpaceController : ControllerBase
    {
        private readonly SpaceService _spaceService;

        public SpaceController(SpaceService spaceService)
        {
            _spaceService = spaceService;
        }

        [HttpPost]
        public async Task<IActionResult> AddSpace([FromBody] SpaceCreateDto dto)
        {
            try
            {
                var space = await _spaceService.AddSpace(dto);
                return Ok(space);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("stablishment/{stablishmentId}")]
        public async Task<IActionResult> GetSpacesByStablishment(Guid stablishmentId)
        {
            var spaces = await _spaceService.GetSpacesByStablishment(stablishmentId);
            return Ok(spaces);
        }

        [HttpPut("{spaceId}")]
        public async Task<IActionResult> UpdateSpace(Guid spaceId, [FromBody] SpaceUpdateDto dto)
        {
            try
            {
                var updated = await _spaceService.UpdateSpace(spaceId, dto);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{spaceId}")]
        public async Task<IActionResult> DeleteSpace(Guid spaceId)
        {
            try
            {
                var result = await _spaceService.DeleteSpace(spaceId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
