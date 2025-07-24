using LokusAPI.Dtos;
using LokusAPI.Services.ClientServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LokusAPI.Controllers
{
    [Route("api/client-images")]
    [ApiController]
    public class ClientImageController : ControllerBase
    {
        private readonly ClientImageService _imageService;

        public ClientImageController(ClientImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost("{clientId}")]
        public async Task<IActionResult> Upload(Guid clientId, IFormFile image)
        {
            if (image == null || image.Length == 0)
                return BadRequest("Imagem inválida.");

            await _imageService.UploadImageAsync(clientId, image);
            return Ok(new { message = "Imagem enviada com sucesso." });
        }

        [HttpGet("{clientId}")]
        public async Task<ActionResult<List<ImageDto>>> GetAll(Guid clientId)
        {
            var images = await _imageService.GetImagesAsync(clientId);
            return Ok(images);
        }
    }
}
