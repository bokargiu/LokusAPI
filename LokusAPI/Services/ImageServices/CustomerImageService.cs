using LokusAPI.Database;
using LokusAPI.Dtos;
using LokusAPI.Models;
using LokusAPI.Services.ClientServices;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LokusAPI.Services.ImageServices
{
    public class CustomerImageService
    {
        private readonly AppDb _context;
        private readonly ImageService _imageService;
        private readonly ICustomerService _customerService;

        public CustomerImageService(AppDb context, ICustomerService customerService, ImageService imageService)
        {
            _context = context;
            _customerService = customerService;
            _imageService = imageService;
        }

        public async Task UploadImageAsync(Guid customerId, IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            var bytes = memoryStream.ToArray();

            var image = new Image
            {
                ImageData = bytes,
                Customer = null
            };
        image.Customer = await _customerService.GetCustomerById(customerId);

        if (image.Customer == null) return;

            await _context.Images.AddAsync(image);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ImageDto>> GetImagesAsync(Guid clientId)
        {
            return await _context.Images
                .Where(img => img.CustomerId == clientId)
                .Select(img => new ImageDto
                {
                    Base64Data = Convert.ToBase64String(img.ImageData)
                })
                .ToListAsync();
        }
        public async Task UploadProfileImage(Guid clientId, IFormFile file)
        {
            try
            {
                await DeleteProfileImage(clientId);
                Image image = await _imageService.PutImage(file);
                Customer customer = await _customerService.GetCustomerById(clientId);
                if (customer == null) return;

                customer.ProfileImage = image;
                image.Customer = customer;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public async Task<Tuple<bool, ImageDto?>> GetProfileImage(Guid customerId)
        {
            Image? img = await _context.Images.Where(i => i.CustomerId != null && i.CustomerId == customerId).FirstOrDefaultAsync();
            if (img == null) return new Tuple<bool, ImageDto?>(false, null);
            ImageDto? imgDto = new ImageDto
            {
                Base64Data = Convert.ToBase64String(img.ImageData)
            };
            return new Tuple<bool, ImageDto?>(true, imgDto);
        }
        public async Task<Image?> GetProfileImageMetaData(Guid customerId)
        {
            return await _context.Images.Where(i => i.CustomerId != null && i.CustomerId == customerId).FirstOrDefaultAsync();
            
        }
        public async Task<string> DeleteProfileImage(Guid CustomerId)
        {
            try
            {
                Image img = await GetProfileImageMetaData(CustomerId);
                if (img != null)
                {
                    _context.Images.Remove(img);
                    await _context.SaveChangesAsync();
                    return "";
                }
                return "img is null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
