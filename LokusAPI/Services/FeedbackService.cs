using LokusAPI.Database;
using LokusAPI.Dtos;
using LokusAPI.Dtos.FeedbackDto;
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

        public async Task<List<FeedbackDto>> GetFeedbacksByCompany(Guid companyId)
        {
            var feedbacks = await _context.Feedbacks
                .Include(f => f.User)
                .Where(f => f.CompanyId == companyId)
                .OrderByDescending(f => f.CreatedAt)
                .ToListAsync();

            return feedbacks.Select(f => new FeedbackDto
            {
                Comment = f.Comment,
                Username = f.User.Username, 
                CreatedAt = f.CreatedAt,
                OverallRating = f.OverallRating,
                ParkingRating = f.ParkingRating,
                WifiRating = f.WifiRating,
                PlugRating = f.PlugRating,
                PriceRating = f.PriceRating
            }).ToList();
        }


        public async Task<FeedbackDto> CreateFeedback(CreateFeedbackRequest request)
        {
            var feedback = new Feedback
            {
                CompanyId = request.CompanyId,
                UserId = request.UserId,
                Comment = request.Comment,
                OverallRating = request.OverallRating,
                ParkingRating = request.ParkingRating,
                WifiRating = request.WifiRating,
                PlugRating = request.PlugRating,
                PriceRating = request.PriceRating
            };

            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            var user = await _context.Users.FindAsync(request.UserId);

            return new FeedbackDto
            {
                Comment = feedback.Comment,
                Username = user?.Username ?? "Anônimo",
                CreatedAt = feedback.CreatedAt,
                OverallRating = feedback.OverallRating,
                ParkingRating = feedback.ParkingRating,
                WifiRating = feedback.WifiRating,
                PlugRating = feedback.PlugRating,
                PriceRating = feedback.PriceRating
            };
        }

        public async Task<bool> UpdateFeedback(Guid feedbackId, CreateFeedbackRequest request)
        {
            var feedback = await _context.Feedbacks.FindAsync(feedbackId);
            if (feedback == null) return false;

            feedback.Comment = request.Comment;
            feedback.OverallRating = request.OverallRating;
            feedback.ParkingRating = request.ParkingRating;
            feedback.WifiRating = request.WifiRating;
            feedback.PlugRating = request.PlugRating;
            feedback.PriceRating = request.PriceRating;

            _context.Feedbacks.Update(feedback);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteFeedback(Guid feedbackId)
        {
            var feedback = await _context.Feedbacks.FindAsync(feedbackId);
            if (feedback == null) return false;

            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<double> GetCompanyOverallAverage(Guid companyId)
        {
            var feedbacks = await _context.Feedbacks
                .Where(f => f.CompanyId == companyId)
                .ToListAsync();

            if (!feedbacks.Any()) return 0;

            return feedbacks.Average(f => f.OverallRating);
        }


    }
}
