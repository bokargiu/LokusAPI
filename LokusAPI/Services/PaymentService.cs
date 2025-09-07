using System;
using LokusAPI.Database;
using LokusAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LokusAPI.Services
{
    public class PaymentService
    {
        private readonly AppDb _context;

        public PaymentService(AppDb context)
        {
            _context = context;
        }

        public async Task<Payment> CreatePaymentSimulado(Guid bookingId, decimal price)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking == null) throw new Exception("Reserva não encontrada.");

            var payment = new Payment
            {
                Id = Guid.NewGuid(),
                ReservaId = bookingId,
                Price = price
                // status e método podem ser adicionados futuramente
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return payment;
        }

        public async Task<List<Payment>> GetPaymentsByCustomer(Guid customerId)
        {
            return await _context.Payments
                .Include(p => p.Booking)
                .Where(p => p.Booking.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<List<Payment>> GetPaymentsBySpace(Guid spaceId)
        {
            return await _context.Payments
                .Include(p => p.Booking)
                .Where(p => p.Booking.SpaceId == spaceId)
                .ToListAsync();
        }

    }

}
