using System;
using LokusAPI.Database;
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

        public async Task<List<Space>> GetSpacesAsync()
        {
            return await _context.Spaces
                .Include(s => s.Schedules)
                .ToListAsync();
        }

        public async Task<Space> AddSpaceAsync(string name, string description, int capacity, decimal price)
        {
            var space = new Space { 
                Name = name,
                Description = description,
                Capacity = capacity,
                PricePerHour = price
            };
            _context.Spaces.Add(space);
            await _context.SaveChangesAsync();
            return space;
        }

        public async Task<Space?> GetSpaceByIdAsync(Guid id)
        {
            return await _context.Spaces
                .Include(s => s.Schedules)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> UpdateSpaceAsync(Guid id, string newName, string? newDescription = null, int? newCapacity = null, decimal? newPriceHour = null )
        {
            var space = await _context.Spaces.FindAsync(id);
            if (space == null) return false;

            space.Name = newName;
            if (newDescription != null)
                space.Description = newDescription;
            if (newCapacity.HasValue) space.Capacity = newCapacity.Value;
            if (newPriceHour.HasValue) space.PricePerHour = newPriceHour.Value;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSpaceAsync(Guid id)
        {
            var space = await _context.Spaces.FindAsync(id);
            if (space == null) return false;

            _context.Spaces.Remove(space);
            await _context.SaveChangesAsync();
            return true;
        }

    }
        
}
