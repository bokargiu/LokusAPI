using LokusAPI.Dtos.StablishmentDto;
using LokusAPI.Models;
using LokusAPI.Services.StablishmentImage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LokusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StablishmentGalleryController : ControllerBase
    {

        private readonly IStablishmentGalleryService _stablishmentGalleryService;

        public StablishmentGalleryController(IStablishmentGalleryService stablishmentGalleryService)
        {
            _stablishmentGalleryService = stablishmentGalleryService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadGallery([FromBody] StablishmentGalleryCreateDto dto)
        {
            if (dto == null)
                return BadRequest("DTO está nulo");

            if (string.IsNullOrEmpty(dto.Base64))
                return BadRequest("Base64 vazio");

            try
            {
                var imageId = await _stablishmentGalleryService.UploadImageAsync(dto);
                var images = await _stablishmentGalleryService.GetImagesAsync(dto.StablishmentId);
                var uploadedImage = images.FirstOrDefault(i => i.Id == imageId);
                return Ok(uploadedImage);
            }
            catch (Exception ex)
            {
                // log aqui
                return StatusCode(500, new { Message = ex.Message, Base64Length = dto.Base64?.Length });
            }
        }

        [HttpGet("stablishment/{stablishmentId}")]
        public async Task<IActionResult> GetImages(Guid stablishmentId)
        {
            var images = await _stablishmentGalleryService.GetImagesAsync(stablishmentId);
            return Ok(images);
        }

        [HttpDelete("{imageId}")]
        public async Task<IActionResult> DeleteImage(Guid imageId)
        {
            var deleted = await _stablishmentGalleryService.DeleteImageAsync(imageId);
            if (!deleted)
                return NotFound(new { Message = "Imagem não encontrada." });

            return NoContent();
        }
    }
}

