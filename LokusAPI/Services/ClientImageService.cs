using LokusAPI.Database;
using LokusAPI.Dtos;
using LokusAPI.Models;
using Microsoft.EntityFrameworkCore;

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
                    Client = null
                };
            image.Client = await _context.Clients.Where(c => clientId
                                                 .Equals(c.Id))
                                                 .FirstOrDefaultAsync();
            if (image.Client == null) return;

                await _context.Images.AddAsync(image);
                await _context.SaveChangesAsync();
            }

            public async Task<List<ImageDto>> GetImagesAsync(Guid clientId)
            {
                return await _context.Images
                    .Where(img => img.Client.Id == clientId)
                    .Select(img => new ImageDto
                    {
                        Id = img.Id,
                        Base64Data = Convert.ToBase64String(img.ImageData)
                    })
                    .ToListAsync();
            }
        

    }
}
