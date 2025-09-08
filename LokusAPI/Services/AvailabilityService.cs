using System;
using System.Text.RegularExpressions;
using LokusAPI.Database;
using LokusAPI.Dtos.AvailabilityDtos;
using LokusAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LokusAPI.Services
{
    public class AvailabilityService
    {
        private readonly AppDb _context;

        public AvailabilityService(AppDb context)
        {
            _context = context;
        }

        public async Task<Availability> AddAvailabilityMVP(AvailabilityCreateDto dto)
        {
            var space = await _context.Spaces.FindAsync(dto.SpaceId);
            if (space == null) throw new Exception("Espaço não encontrado.");

            var availability = new Availability
            {
                Id = Guid.NewGuid(),
                SpaceId = dto.SpaceId,
                DiaSemana = dto.DiaSemana,
                HoraInicio = dto.HoraInicio,
                HoraFim = dto.HoraFim,
                Status = AvailabilityStatus.Disponivel
            };

            _context.Availabilities.Add(availability);
            await _context.SaveChangesAsync();

            return availability;
        }

        public async Task<List<Availability>> GetAvailabilitiesBySpace(Guid spaceId)
        {
            return await _context.Availabilities
                .Where(a => a.SpaceId == spaceId)
                .OrderBy(a => a.DiaSemana)
                .ThenBy(a => a.HoraInicio)
            .ToListAsync();
        }

        //Marca um horário como indisponível
        public async Task<Availability> SetUnavailable(Guid availabilityId)
        {
            var availability = await _context.Availabilities.FindAsync(availabilityId);
            if (availability == null) throw new Exception("Disponibilidade não encontrada.");

            availability.Status = AvailabilityStatus.Indisponivel;
            await _context.SaveChangesAsync();

            return availability;
        }
    }
}
