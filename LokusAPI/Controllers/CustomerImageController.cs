using LokusAPI.Dtos;
using LokusAPI.Models;
using LokusAPI.Services.ImageServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace LokusAPI.Controllers
{
    [Route("api/customer-images")]
    [ApiController]
    public class CustomerImageController : ControllerBase
    {
        private readonly CustomerImageService _imageService;

        public CustomerImageController(CustomerImageService imageService)
        {
            _imageService = imageService;
        }

        //[HttpPost("{clientId}")]
        //[Consumes("multipart/form-data")]
        //public async Task<IActionResult> Upload(Guid clientId,[FromForm] IFormFile image)
        //{
        //    if (image == null || image.Length == 0)
        //        return BadRequest("Imagem inválida.");

        //    await _imageService.UploadImageAsync(clientId, image);
        //    return Ok(new { message = "Imagem enviada com sucesso." });
        //}

        [HttpGet("{CustomerId}")]
        public async Task<ActionResult<List<ImageDto>>> GetAll(Guid CustomerId)
        {
            var images = await _imageService.GetImagesAsync(CustomerId);
            return Ok(images);
        }
        [HttpPost("profile/{CustomerId}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadProfileImage(Guid CustomerId, IFormFile file)
        {
            try
            {
                //await _imageService.UploadProfileImage(clientId, file);
                //return Ok();

                await _imageService.UploadProfileImage(CustomerId, file);
                return Ok(new { file.FileName });

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("profile/{CustomerId}")]
        public async Task<IActionResult> GetProfileImage(Guid CustomerId)
        {
            try
            {
                Tuple<bool, ImageDto?> response = await _imageService.GetProfileImage(CustomerId);
                if (response.Item1 == true) return Ok(new { response.Item2.Base64Data });
                return BadRequest();
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpDelete("profile/{CustomerId}")]
        public async Task<IActionResult> DeletProfileImage(Guid CustomerId)
        {
            try
            {
                return Ok(await _imageService.DeleteProfileImage(CustomerId));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
