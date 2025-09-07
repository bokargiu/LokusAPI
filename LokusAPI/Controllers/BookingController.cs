using LokusAPI.Dtos.BookingDtos;
using LokusAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LokusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingService _bookingService;

        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] BookingCreateDto dto)
        {
            try
            {
                var booking = await _bookingService.CreateBooking(dto);
                return Ok(booking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{bookingId}/cancel/{customerId}")]
        public async Task<IActionResult> CancelBooking(Guid bookingId, Guid customerId)
        {
            try
            {
                var booking = await _bookingService.CancelBooking(bookingId, customerId);
                return Ok(booking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("space/{spaceId}")]
        public async Task<IActionResult> GetBookingsBySpace(Guid spaceId)
        {
            var bookings = await _bookingService.GetBookingsBySpace(spaceId);
            return Ok(bookings);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetBookingsByCustomer(Guid customerId)
        {
            var bookings = await _bookingService.GetBookingsByCustomer(customerId);
            return Ok(bookings);
        }


    }
}
