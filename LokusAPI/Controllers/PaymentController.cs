using LokusAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LokusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("{bookingId}/simulated")]
        public async Task<IActionResult> CreatePaymentSimulado(Guid bookingId, decimal price)
        {
            try
            {
                var payment = await _paymentService.CreatePaymentSimulado(bookingId, price);
                return Ok(payment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetPaymentsByCustomer(Guid customerId)
        {
            var payments = await _paymentService.GetPaymentsByCustomer(customerId);
            return Ok(payments);
        }

        [HttpGet("space/{spaceId}")]
        public async Task<IActionResult> GetPaymentsBySpace(Guid spaceId)
        {
            var payments = await _paymentService.GetPaymentsBySpace(spaceId);
            return Ok(payments);
        }
    }
}
