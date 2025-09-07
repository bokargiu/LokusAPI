using LokusAPI.Database;
using LokusAPI.Dtos.SpaceDtos.SpaceDto;
using LokusAPI.Dtos.SpaceDtos;
using LokusAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LokusAPI.Services
{
    public class SpaceService
    {

        private readonly AppDb _context;
        public SpaceService(AppDb context)
        {
            _context = context;
        }

        public async Task<Space> AddSpace(SpaceCreateDto dto)
        {
            var stablishment = await _context.Stablishments.FindAsync(dto.StablishmentId);
            if (stablishment == null) throw new Exception("Estabelecimento não encontrado.");

            var space = new Space
            {
                Id = Guid.NewGuid(),
                StablishmentId = dto.StablishmentId,
                Name = dto.Name,
                Capacity = dto.Capacity,
                Description = dto.Description,
                Price = dto.Price,
                PriceEnum = dto.PriceEnum
            };

            _context.Spaces.Add(space);
            await _context.SaveChangesAsync();

            return space;
        }

        public async Task<List<Space>> GetSpacesByStablishment(Guid stablishmentId)
        {
            return await _context.Spaces
                .Where(s => s.StablishmentId == stablishmentId)
                .Include(s => s.Bookings)
                .Include(s => s.Stablishment)
                .ToListAsync();
        }

        public async Task<Space> UpdateSpace(Guid spaceId, SpaceUpdateDto dto)
        {
            var space = await _context.Spaces.FindAsync(spaceId);
            if (space == null) throw new Exception("Espaço não encontrado.");

            space.Name = dto.Name ?? space.Name;
            space.Capacity = dto.Capacity != 0 ? dto.Capacity : space.Capacity;
            space.Description = dto.Description ?? space.Description;
            space.Price = dto.Price != 0 ? dto.Price : space.Price;
            space.PriceEnum = dto.PriceEnum;

            await _context.SaveChangesAsync();
            return space;
        }

        public async Task<bool> DeleteSpace(Guid spaceId)
        {
            var space = await _context.Spaces.FindAsync(spaceId);
            if (space == null) throw new Exception("Espaço não encontrado.");

            _context.Spaces.Remove(space);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
