using System.Numerics;
using LokusAPI.Database;
using LokusAPI.Dtos;
using LokusAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LokusAPI.Services
{
    public class SubscriptionService
    {
        private readonly AppDb _context;

        public SubscriptionService(AppDb context)
        {
            _context = context;
        }

        public async Task<List<Subscription>> SubscriptionPlanList()
        {
            return await _context.Subscriptions.ToListAsync();
        }



        public async Task<Subscription> CreatePlan(SubscriptionDto dto)
        {

            if (!Enum.TryParse<SubscriptionType>(dto.Type, true, out var parsedType))
            {
                throw new ArgumentException("Tipo de assinatura inválido. Use 'Customer' ou 'Company'.");
            }

            var subscription = new Subscription
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Type = parsedType.ToString()
            };

            _context.Subscriptions.Add(subscription);
            await _context.SaveChangesAsync();

            return subscription;
        }

        public async Task<bool> RemovePlanAsync(int id)
        {
            var plan = await _context.Subscriptions.FindAsync(id);
            if (plan == null) return false;

            _context.Subscriptions.Remove(plan);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Subscription?> UpdateSubscriptionAsync(int id, SubscriptionDto dto)
        {
            var plan = await _context.Subscriptions.FindAsync(id);
            if (plan == null) return null;

            plan.Name = dto.Name;
            plan.Description = dto.Description;
            plan.Price = dto.Price;
            plan.Type = dto.Type;

            await _context.SaveChangesAsync();
            return plan;
        }

        public async Task<List<Subscription>> GetCompanyPlansAsync()
        {
            return await _context.Subscriptions
                .Where( s => s.Type == "company")
                .ToListAsync();
        }

        public async Task<List<Subscription>> GetCustomerPlansAsync()
        {
            return await _context.Subscriptions
                .Where(s => s.Type == "customer")
                .ToListAsync();
        }
    }
}
