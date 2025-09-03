using LokusAPI.Database;
using LokusAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LokusAPI.Services
{
    public class ScheduleService
    {
        private readonly AppDb _context;

        public ScheduleService(AppDb context)
        {
            _context = context;
        }

        public async Task<List<Schedule>> GetSchedulesAsync()
        {
            return await _context.Schedules
                .Include(s => s.Space)
                .ToListAsync();
        }

        public async Task<Schedule> AddScheduleAsync(Guid spaceId, string dayOfWeek, string time)
        {
            var schedule = new Schedule
            {
                SpaceId = spaceId,
                DayOfWeek = dayOfWeek,
                Time = time
            };

            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();
            return schedule;
        }

        public async Task<Schedule?> GetScheduleByIdAsync(Guid id)
        {
            return await _context.Schedules
                .Include(s => s.Space)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> UpdateScheduleAsync(Guid id, Guid spaceId, string dayOfWeek, string time)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null) return false;

            schedule.SpaceId = spaceId;
            schedule.DayOfWeek = dayOfWeek;
            schedule.Time = time;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteScheduleAsync(Guid id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null) return false;

            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
