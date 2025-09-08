using LokusAPI.Database;
using LokusAPI.Dtos;
using LokusAPI.Dtos.FeedbackDto;
using LokusAPI.Dtos.FeedbackDtos;
using LokusAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LokusAPI.Services
{
    public class FeedbackService
    {

        private readonly AppDb _context;

        public FeedbackService(AppDb context)
        {
            _context = context;
        }

            public async Task<FeedbackAverageDto> CreateFeedback(CreateFeedbackRequestDto request, Feedback.OverallRating overallRating)
            {
                var feedback = new Feedback
                {
                    StablishmentId = request.StablishmentId,
                    UserId = request.UserId,
                    Comment = request.Comment,
                    OverallRatings = request.OverallRating,
                    ParkingRatings = request.ParkingRating,
                    WifiRatings = request.WifiRating,
                    PlugRatings = request.PlugRating,
                    PriceRatings = request.PriceRating,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Feedbacks.Add(feedback);
                await _context.SaveChangesAsync();

                return await GetFeedbackAveragesByStablishment(request.StablishmentId);
            }


            public async Task<FeedbackAverageDto?> UpdateFeedback(Guid feedbackId, CreateFeedbackRequestDto request)
            {
                var feedback = await _context.Feedbacks.FindAsync(feedbackId);
                if (feedback == null) return null;

                feedback.Comment = request.Comment;
                feedback.OverallRatings = request.OverallRating;
                feedback.ParkingRatings = request.ParkingRating;
                feedback.WifiRatings = request.WifiRating;
                feedback.PlugRatings = request.PlugRating;
                feedback.PriceRatings = request.PriceRating;

                _context.Feedbacks.Update(feedback);
                await _context.SaveChangesAsync();

                return await GetFeedbackAveragesByStablishment(feedback.StablishmentId);
            }
            public async Task<FeedbackAverageDto?> DeleteFeedback(Guid feedbackId)
            {
                var feedback = await _context.Feedbacks.FindAsync(feedbackId);
                if (feedback == null) return null;

                var stablishmentId = feedback.StablishmentId;

                _context.Feedbacks.Remove(feedback);
                await _context.SaveChangesAsync();

                return await GetFeedbackAveragesByStablishment(stablishmentId);
            }


            public async Task<FeedbackAverageDto> GetFeedbackAveragesByStablishment(Guid stablishmentId)
            {
                var feedbacks = await _context.Feedbacks
                    .Where(f => f.StablishmentId == stablishmentId)
                    .ToListAsync();

                if (!feedbacks.Any())
                {
                    return new FeedbackAverageDto
                    {
                        OverallAverage = 0,
                        ParkingAverage = 0,
                        WifiAverage = 0,
                        PlugAverage = 0,
                        PriceAverage = 0
                    };
                }

                return new FeedbackAverageDto
                {
                    OverallAverage = feedbacks.Average(f => (int)f.OverallRatings),
                    ParkingAverage = feedbacks.Average(f => (int)f.ParkingRatings),
                    WifiAverage = feedbacks.Average(f => (int)f.WifiRatings),
                    PlugAverage = feedbacks.Average(f => (int)f.PlugRatings),
                    PriceAverage = feedbacks.Average(f => (int)f.PriceRatings)
                };
            }
        }


    
}
