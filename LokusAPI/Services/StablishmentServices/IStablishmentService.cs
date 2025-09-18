using LokusAPI.Dtos.StablishmentDto;

namespace LokusAPI.Services.StablishmentServices
{
    public interface IStablishmentService
    {
        Task<List<StablishmentResponseDto>> GetStablishmentsByUserIdAsync(Guid userId);

        Task<StablishmentResponseDto?> CreateStablishmentAsync(Guid userId, StablishmentCreateDto dto);

        Task<StablishmentResponseDto?> GetStablishmentById(Guid id);

        Task<StablishmentResponseDto?> UpdateStablishmentAsync(Guid id, StablishmentUpdateDto dto);

    }
}
