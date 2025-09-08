using LokusAPI.Database;
using LokusAPI.Models;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace LokusAPI.Services.ImageServices
{
    public class ImageService
    {
        protected readonly AppDb _context;
        public ImageService(AppDb context)
        {
            _context = context;
        }
        public async Task<Image> PutImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Arquivo inválido");

            await using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            var bytes = memoryStream.ToArray();

            var image = new Image();
            image.ImageData = bytes;

            await _context.Images.AddAsync(image);
            await _context.SaveChangesAsync();
            return image;
        }
        public async Task DelImage(Guid Id)
        {
            Image img = await _context.Images.Where(i => i.Id == Id).FirstOrDefaultAsync();
            if (img == null) return;
            _context.Images.Remove(img);
            await _context.SaveChangesAsync();
        }

    }
}
