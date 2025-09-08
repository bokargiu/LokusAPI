using LokusAPI.Dtos.FeedbackDto;
using LokusAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        //Obter todos os feedbacks de uma empresa
        [HttpGet("company/{companyId}")]
        public async Task<ActionResult<List<FeedbackDto>>> GetFeedbacks(Guid companyId)
        {
            return Ok(await _feedbackService.GetFeedbacksByCompany(companyId));
        }

        //Obter a média geral dos ratings de uma empresa
        [HttpGet("company/{companyId}/average")]
        public async Task<ActionResult<double>> GetCompanyAverage(Guid companyId)
        {
            var average = await _feedbackService.GetCompanyOverallAverage(companyId);
            return Ok(average);
        }

        //Criar novo feedback
        [HttpPost]
        public async Task<ActionResult<FeedbackDto>> CreateFeedback([FromBody] CreateFeedbackRequestDto request)
        {
            var feedback = await _feedbackService.CreateFeedback(request, OverallRating);
            return Ok(feedback);
        }

        // Atualizar um feedback existente
        [HttpPut("{feedbackId}")]
        public async Task<ActionResult> UpdateFeedback(Guid feedbackId, [FromBody] CreateFeedbackRequestDto request)
        {
            var success = await _feedbackService.UpdateFeedback(feedbackId, request);
            return success ? NoContent() : NotFound();
        }

        // Deletar um feedback
        [HttpDelete("{feedbackId}")]
        public async Task<ActionResult> DeleteFeedback(Guid feedbackId)
        {
            var success = await _feedbackService.DeleteFeedback(feedbackId);
            return success ? NoContent() : NotFound();
        }

    }
}
