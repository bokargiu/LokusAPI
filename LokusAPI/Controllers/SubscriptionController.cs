using LokusAPI.Database;
using LokusAPI.Dtos;
using LokusAPI.Models;
using LokusAPI.Services;
using LokusAPI.Services.CompanyService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LokusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly SubscriptionService _service;

        public SubscriptionController(SubscriptionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Subscription>>> GetAll()
        {
            var result = await _service.SubscriptionPlanList();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Subscription>> CreatePlan ([FromBody] SubscriptionDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.CreatePlan(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subscription>> GetById(Guid id)
        {
            var subscriptions = await _service.SubscriptionPlanList();
            var item = subscriptions.FirstOrDefault(s => s.Id == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Subscription>> Update(int id, [FromBody] SubscriptionDto dto)
        {
            var updated = await _service.UpdateSubscriptionAsync(id, dto);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removed = await _service.RemovePlanAsync(id);
            if (!removed)
                return NotFound();

            return NoContent();
        }

        [HttpGet("company")]
        public async Task<ActionResult<List<Subscription>>> GetCompanyPlans()
        {
            var result = await _service.GetCompanyPlansAsync();
            return Ok(result);
        }

        [HttpGet("customer")]
        public async Task<ActionResult<List<Subscription>>> GetCustomerPlans()
        {
            var result = await _service.GetCustomerPlansAsync();
            return Ok(result);
        }


    }
}
