using LokusAPI.Dtos.FeedbackDto;
using LokusAPI.Dtos.FeedbackDtos;
using LokusAPI.Models;
using LokusAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static LokusAPI.Models.Feedback;

namespace LokusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackService _feedbackService;

        public FeedbackController(FeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        // Obter todos os feedbacks de uma empresa
        [HttpGet("stablishment/{stablishmentId}/feedbacks")]
        public async Task<ActionResult<List<FeedbackDto>>> GetFeedbacks(Guid stablishmentId)
        {
            var feedbacks = await _feedbackService.GetFeedbacksByStablishment(stablishmentId);
            return Ok(feedbacks);
        }

        // Obter médias de uma empresa
        [HttpGet("stablishment/{stablishmentId}/average")]
        public async Task<ActionResult<FeedbackAverageDto>> GetCompanyAverage(Guid stablishmentId)
        {
            var averages = await _feedbackService.GetFeedbackAveragesByStablishment(stablishmentId);
            return Ok(averages);
        }





        [HttpPost("stablishment/{stablishmentId}/feedback")]
        public async Task<ActionResult<FeedbackAverageDto>> CreateFeedback(Guid stablishmentId, [FromBody] CreateFeedbackRequestDto request)
        {
            try
            {
                // pega o userId do token JWT
                var userId = Guid.Parse(User.FindFirst("sub").Value);

                var result = await _feedbackService.CreateFeedback(stablishmentId, userId, request);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // Deletar um feedback
        [HttpDelete("{feedbackId}")]
        public async Task<ActionResult> DeleteFeedback(Guid feedbackId)
        {
            var success = await _feedbackService.DeleteFeedback(feedbackId);
            return Ok();// success ? NoContent() : NotFound();
        }

    }
}
