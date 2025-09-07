using System;
using System.Data;
using LokusAPI.Database;
using LokusAPI.Dtos.StablishmentDto;
using LokusAPI.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace LokusAPI.Services
{
    public class StablishmentService
    {
        private readonly AppDb _context;

        public StablishmentService(AppDb context)
        {
            _context = context;
        }

        public async Task<List<StablishmentResponseDto>> GetStablishmentsByUserIdAsync(Guid userId)
        {
            var company = await _context.Companies
                .Include(c => c.Stablishments)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (company == null) return new List<StablishmentResponseDto>();

            // Retorna apenas Id e Name
            return company.Stablishments
                .Select(s => new StablishmentResponseDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    CompanyId = company.Id
                })
                .ToList();
        }
    }
}
    


