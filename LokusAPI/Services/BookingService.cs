using System;
using LokusAPI.Database;
using LokusAPI.Dtos.BookingDtos;
using LokusAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LokusAPI.Services
{
    public class BookingService
    {
        private readonly AppDb _context;

        public BookingService(AppDb context)
        {
            _context = context;
        }

        public async Task<Booking> CreateBookingAsync(BookingCreateDto dto)
        {
            var space = await _context.Spaces.FindAsync(dto.SpaceId);
            if (space == null) throw new Exception("Espaço não encontrado.");


            var diaSemana = dto.Data.DayOfWeek;
            var availability = await _context.Availabilities
                .Where(a => a.SpaceId == dto.SpaceId
                            && a.DiaSemana == diaSemana
                            && a.Status == AvailabilityStatus.Disponivel)
                .ToListAsync();

            if (!availability.Any(a => dto.HoraInicio >= a.HoraInicio && dto.HoraFim <= a.HoraFim))
                throw new Exception("O horário solicitado não está disponível.");

            // verifica conflito com outras reservas
            var conflito = await _context.Bookings.AnyAsync(b =>
                b.SpaceId == dto.SpaceId &&
                b.Data.Date == dto.Data.Date &&
                (
                    (dto.HoraInicio >= b.HoraInicio && dto.HoraInicio < b.HoraFim) ||
                    (dto.HoraFim > b.HoraInicio && dto.HoraFim <= b.HoraFim) ||
                    (dto.HoraInicio <= b.HoraInicio && dto.HoraFim >= b.HoraFim)
                )
            );

            if (conflito) throw new Exception("O horário já está reservado.");

            // ria a reserva já como "Confirmada"
            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                SpaceId = dto.SpaceId,
                CustomerId = dto.CustomerId,
                Data = dto.Data,
                HoraInicio = dto.HoraInicio,
                HoraFim = dto.HoraFim,
                Status = BookingStatus.Confirmado
            };

            _context.Bookings.Add(booking);

            await _context.SaveChangesAsync();

            return booking;
        }

        public async Task<Booking> CancelBookingAsync(Guid bookingId, Guid customerId)
        {

            var booking = await _context.Bookings
                .FirstOrDefaultAsync(b => b.Id == bookingId && b.CustomerId == customerId);

            if (booking == null)
                throw new Exception("Reserva não encontrada ou não pertence ao usuário.");

            // atualiza status para "Cancelado"
            booking.Status = BookingStatus.Cancelado;

            await _context.SaveChangesAsync();

            return booking;
        }

        public async Task<List<BookingResponseDto>> GetBookingsBySpaceAsync(Guid spaceId)
        {
            var bookings = await _context.Bookings
               .Include(b => b.Customer)
               .Where(b => b.SpaceId == spaceId)
               .ToListAsync();

            return bookings.Select(b => new BookingResponseDto(
                b.Id,
                b.SpaceId,
                b.CustomerId,
                b.Data,
                b.HoraInicio,
                b.HoraFim,
                b.Status.ToString()
            )).ToList();
        }

        public async Task<List<BookingResponseDto>> GetBookingsByCustomerAsync(Guid customerId)
        {
            var bookings = await _context.Bookings
                .Include(b => b.Space)
                .Where(b => b.CustomerId == customerId)
                .ToListAsync();

            return bookings.Select(b => new BookingResponseDto(
                b.Id,
                b.SpaceId,
                b.CustomerId,
                b.Data,
                b.HoraInicio,
                b.HoraFim,
                b.Status.ToString()
            )).ToList();
        }
    }
}
