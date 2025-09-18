using LokusAPI.Dtos;
using LokusAPI.Services.ImageServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LokusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ImageService _imageService;
        public ImageController(ImageService imageService)
        {
            _imageService = imageService;
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid Id)
        {
            try
            {
                var image = await _imageService.GetImageAsync(Id);
                return image != null ? Ok(new { image }) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostImageAsync(IFormFile file)
        {
            try
            {
                await _imageService.PutImage(file);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("LokusImage")]
        public async Task<IActionResult> GetLokusImage()
        {
            try
            {
                ImageDto image = new ImageDto();
                image.Base64Data = await _imageService.GetImageAsync(new Guid("08ddf17c-1a4a-4c67-8380-78c1d7e2cbb7"));
                return image.Base64Data != null ? Ok(new { image }) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
