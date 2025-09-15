using LokusAPI.Dtos.StablishmentDto;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LokusAPI.Services.StablishmentServices;
using System.Reflection.Metadata.Ecma335;

namespace LokusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StablishmentController : ControllerBase
    {
        private readonly IStablishmentService _stablishmentService;

        public StablishmentController(IStablishmentService stablishmentService)
        {
            _stablishmentService = stablishmentService;
        }

        // GET /api/Stablishment/my-stablishment
        [HttpGet("my-stablishment")]
        [Authorize]
        public async Task<IActionResult> GetMyStablishments()
        {
            try
            {
                // Pega a claim do token
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value;
                Console.WriteLine($"Claim PrimarySid: {userIdClaim}");

                if (string.IsNullOrEmpty(userIdClaim))
                {
                    Console.WriteLine("Claim do usuário não encontrada");
                    return BadRequest("ID do usuário inválido.");
                }

                if (!Guid.TryParse(userIdClaim, out Guid userGuid))
                {
                    Console.WriteLine("Claim do usuário não é um Guid válido");
                    return BadRequest("ID do usuário inválido.");
                }

                Console.WriteLine($"UserGuid válido: {userGuid}");

                // Chama o service para pegar os stablishments
                var stablishments = await _stablishmentService.GetStablishmentsByUserIdAsync(userGuid);

                Console.WriteLine($"Quantidade de stablishments encontrados: {stablishments?.Count}");

                return Ok(stablishments);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no controller: {ex}");
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPost("new-stablishment")]
        //[Authorize]
        public async Task<IActionResult> AddNewStablishment([FromBody] StablishmentCreateDto dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest("O corpo da requisição (dto) está vazio ou inválido.");

                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value;

                if (string.IsNullOrEmpty(userIdClaim))
                    return BadRequest("ID do usuário inválido.");

                if (!Guid.TryParse(userIdClaim, out Guid userGuid))
                    return BadRequest($"Claim 'primarysid' não é um Guid válido: {userIdClaim}");

                var createdStablishment = await _stablishmentService.CreateStablishmentAsync(userGuid, dto);

                if (createdStablishment == null)
                    return StatusCode(500, "Erro ao criar estabelecimento (empresa não encontrada).");

                return Ok(createdStablishment);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no AddNewStablishment: {ex.Message}");
                return StatusCode(500, "Ocorreu um erro inesperado.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStablishmentById(Guid id)
        {
            try
            {
                var response = await _stablishmentService.GetStablishmentById(id);

                if (response == null)
                    return NotFound(new { message = "Estabelecimento não encontrado." });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao buscar estabelecimento.", details = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateStablishment(Guid id, [FromBody] StablishmentUpdateDto dto)
        {
            try
            {
                var updated = await _stablishmentService.UpdateStablishmentAsync(id, dto);

                if (updated == null) return NotFound(new { message = "Estabelecimento não encontrado." });

                return Ok(updated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao atualizar estabelecimento.", details = ex.Message });
            }

        }
    }

}

