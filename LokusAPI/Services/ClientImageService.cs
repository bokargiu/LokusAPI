using LokusAPI.Database;
using LokusAPI.Dtos;
using LokusAPI.Models;

namespace LokusAPI.Services
{
    public class ClientImageService
    {
            private readonly AppDb _context;

            public ClientImageService(AppDb context)
            {
                _context = context;
            }

            public async Task UploadImageAsync(Guid clientId, IFormFile file)
            {
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                var bytes = memoryStream.ToArray();

                var image = new Image
                {
                    ImageData = bytes,
                    ClientId = clientId
                };

                _context.Images.Add(image);
                await _context.SaveChangesAsync();
            }

            public async Task<List<ImageDto>> GetImagesAsync(Guid clientId)
            {
                return await _context.Images
                    .Where(img => img.ClientId == clientId)
                    .Select(img => new ImageDto
                    {
                        Id = img.Id,
                        Base64Data = Convert.ToBase64String(img.ImageData)
                    })
                    .ToListAsync();
            }
        

    }
}
