using System.Buffers.Text;
using LokusAPI.Database;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using LokusAPI.Dtos.StablishmentDto;
using LokusAPI.Models;


namespace LokusAPI.Services.StablishmentImage
{
    public class StablishmentGalleryService : IStablishmentGalleryService
    {
        private readonly AppDb _context;
        public StablishmentGalleryService(AppDb context)
        {
            _context = context;
        }

        public async Task<Guid> UploadImageAsync(StablishmentGalleryCreateDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.Base64))
                throw new ArgumentException("Imagem inválida.");

            var count = await _context.StablishmentGalleries.CountAsync(i => i.StablishmentId == dto.StablishmentId);
            if (count >= 10)
                throw new InvalidOperationException("Limite máximo de 10 fotos atingido.");

            // Remove prefixo do Base64 caso exista
            var base64Data = dto.Base64.Contains(",") ? dto.Base64.Split(',')[1] : dto.Base64;
            var bytes = Convert.FromBase64String(base64Data);

            var image = new StablishmentGallery
            {
                Id = Guid.NewGuid(),
                StablishmentId = dto.StablishmentId,
                FileName = dto.FileName,
                Data = bytes
            };

            _context.StablishmentGalleries.Add(image);
            await _context.SaveChangesAsync();

            return image.Id;
        }


        public async Task<IEnumerable<StablishmentGalleryDto>> GetImagesAsync(Guid stablishmentId)
        {
            var images = await _context.StablishmentGalleries
                .Where(i => i.StablishmentId == stablishmentId)
                .ToListAsync();

            return images.Select(i => new StablishmentGalleryDto
            {
                Id = i.Id,
                FileName = i.FileName,
                Base64Data = Convert.ToBase64String(i.Data)
            });
        }

        public async Task<bool> DeleteImageAsync(Guid imageId)
        {
            var image = await _context.StablishmentGalleries.FindAsync(imageId);
            if (image == null)
                return false;

            _context.StablishmentGalleries.Remove(image);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

