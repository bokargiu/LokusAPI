using System;
using System.Data;
using System.IO;
using System.Net;
using System.Reflection.Emit;
using LokusAPI.Database;
using LokusAPI.Dtos.StablishmentDto;
using LokusAPI.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LokusAPI.Services.StablishmentServices
{
    public class StablishmentService : IStablishmentService
    {
        private readonly AppDb _context;

        public StablishmentService(AppDb context)
        {
            _context = context;
        }

        public async Task<List<StablishmentResponseDto>> GetStablishmentsByUserIdAsync(Guid userId)
        {
            try
            {
                var company = await _context.Companies
                    .Include(c => c.Stablishments)
                    .FirstOrDefaultAsync(c => c.UserId == userId);

                if (company == null)
                {
                    Console.WriteLine("Nenhuma empresa encontrada");
                    return new List<StablishmentResponseDto>();
                }

                var stablishments = company.Stablishments?
                    .Select(s => new StablishmentResponseDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                        CompanyId = company.Id
                    })
                    .ToList() ?? new List<StablishmentResponseDto>();

                return stablishments;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no Service: {ex}");
                throw; // mantém a exceção para o controller capturar
            }



        }

        public async Task<StablishmentResponseDto?> CreateStablishmentAsync(Guid userId, StablishmentCreateDto dto)
        {
            var company = await _context.Companies
                .Include(c => c.Stablishments)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (company == null)
                return null;

            var stablishment = new Stablishment
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                VirtualName = dto.VirtualName,
                Description = dto.Description,
                Contact = dto.Contact,
                CompanyId = company.Id 
            };

            _context.Stablishments.Add(stablishment);
            await _context.SaveChangesAsync();

            return new StablishmentResponseDto(stablishment);
        }

        public async Task<StablishmentResponseDto?> GetStablishmentById(Guid id)
        {
            var stablishment = await _context.Stablishments
                .Include(s => s.Address)
                .Include(s => s.Galleries)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (stablishment == null) return null;

            return new StablishmentResponseDto(stablishment);
        }

        public async Task<StablishmentResponseDto?> UpdateStablishmentAsync(Guid id, StablishmentUpdateDto dto)
        {
            var stablishment = await _context.Stablishments.FirstOrDefaultAsync(s => s.Id == id);

            if (stablishment == null) return null;
            //atualizar os campos no front
            stablishment.VirtualName = dto.VirtualName;
            stablishment.Description = dto.Description;

            await _context.SaveChangesAsync();

            return new StablishmentResponseDto(stablishment);
        }




    }
}

    








