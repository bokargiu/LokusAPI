using LokusAPI.Dtos.SpaceDto;
using LokusAPI.Dtos.SpaceDtos;
using LokusAPI.Dtos.SpaceDtos.SpaceDto;
using LokusAPI.Models;
using LokusAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("byUser")]
        public async Task<IActionResult> GetByUser([FromQuery] Guid userId)
        {
            try
            {
                var stablishments = await _spaceService.GetStablishmentsByUser(userId);
                if (stablishments == null || !stablishments.Any())
                    return NotFound("Nenhum estabelecimento encontrado para este usuário.");

                return Ok(stablishments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("byUser/spaces")]
        public async Task<IActionResult> GetSpacesByUser([FromQuery] Guid userId)
        {
            try
            {
                var spaces = await _spaceService.GetSpacesByUser(userId);
                return Ok(spaces);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
