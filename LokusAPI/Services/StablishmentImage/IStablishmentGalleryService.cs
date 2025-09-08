using LokusAPI.Dtos.StablishmentDto;

namespace LokusAPI.Services.StablishmentImage
{
    public interface IStablishmentGalleryService
    {
        Task<Guid> UploadImageAsync(StablishmentGalleryCreateDto dto);
        Task<IEnumerable<StablishmentGalleryDto>> GetImagesAsync(Guid stablishmentId);
        Task<bool> DeleteImageAsync(Guid imageId);
    }
}
