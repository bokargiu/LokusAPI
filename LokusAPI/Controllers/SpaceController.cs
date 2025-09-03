using LokusAPI.Dtos;
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

        [HttpGet]
        public async Task<ActionResult<List<Space>>> GetSpaces()
        {
            var spaces = await _spaceService.GetSpacesAsync();
            return Ok(spaces);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Space>> GetSpace(Guid id)
        {
            var space = await _spaceService.GetSpaceByIdAsync(id);
            if (space == null) return NotFound();
            return Ok(space);
        }

        [HttpPost]
        public async Task<ActionResult<Space>> AddSpace([FromBody] SpaceDto dto)
        {
            var space = await _spaceService.AddSpaceAsync(dto.Name, dto.Description, dto.Capacity, dto.PricePerHour);
            return CreatedAtAction(nameof(GetSpace), new { id = space.Id }, space);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSpace(Guid id, [FromBody] SpaceDto dto)
        {
            var updated = await _spaceService.UpdateSpaceAsync(id, dto.Name, dto.Description, dto.Capacity, dto.PricePerHour);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpace(Guid id)
        {
            var deleted = await _spaceService.DeleteSpaceAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
