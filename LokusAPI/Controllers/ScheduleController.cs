using LokusAPI.Dtos;
using LokusAPI.Models;
using LokusAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LokusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly ScheduleService _scheduleService;

        public ScheduleController(ScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Schedule>>> GetSchedules()
        {
            var schedules = await _scheduleService.GetSchedulesAsync();
            return Ok(schedules);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetSchedule(Guid id)
        {
            var schedule = await _scheduleService.GetScheduleByIdAsync(id);
            if (schedule == null) return NotFound();
            return Ok(schedule);
        }

        [HttpPost]
        public async Task<ActionResult<Schedule>> AddSchedule([FromBody] ScheduleDto dto)
        {
            var schedule = await _scheduleService.AddScheduleAsync(dto.SpaceId, dto.DayOfWeek, dto.Time);

            return CreatedAtAction(nameof(GetSchedule), new { id = schedule.Id }, schedule);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSchedule(Guid id, [FromBody] ScheduleDto dto)
        {
            var updated = await _scheduleService.UpdateScheduleAsync(id, dto.SpaceId, dto.DayOfWeek, dto.Time);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(Guid id)
        {
            var deleted = await _scheduleService.DeleteScheduleAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
