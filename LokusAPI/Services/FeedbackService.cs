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

        public async Task<FeedbackAverageDto> CreateFeedback(Guid stablishmentId, Guid userId, CreateFeedbackRequestDto request)
        {
            var existing = await _context.Feedbacks
                .FirstOrDefaultAsync(f => f.StablishmentId == stablishmentId && f.UserId == userId);

            if (existing != null)
                throw new InvalidOperationException("Usuário já avaliou este local.");

            var feedback = new Feedback
            {
                StablishmentId = stablishmentId,
                UserId = userId,
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

            return await GetFeedbackAveragesByStablishment(stablishmentId);
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

        public async Task<List<FeedbackDto>> GetFeedbacksByStablishment(Guid stablishmentId)
        {
            var feedbacks = await _context.Feedbacks
                .Where(f => f.StablishmentId == stablishmentId)
                .Include(f => f.User) // importante para trazer o Username
                .OrderByDescending(f => f.CreatedAt) // opcional: mais recentes primeiro
                .ToListAsync();

            return feedbacks.Select(f => new FeedbackDto
            {
                Comment = f.Comment,
                OverallRating = (int)f.OverallRatings,
                ParkingRating = (int)f.ParkingRatings,
                WifiRating = (int)f.WifiRatings,
                PlugRating = (int)f.PlugRatings,
                PriceRating = (int)f.PriceRatings,
                Username = f.User.Username, // precisa garantir que o User tem Username
                CreatedAt = f.CreatedAt
            }).ToList();
        }

    }



}
