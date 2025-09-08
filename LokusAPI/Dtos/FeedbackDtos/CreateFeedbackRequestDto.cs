using LokusAPI.Models;

namespace LokusAPI.Dtos.FeedbackDto
{
    public class CreateFeedbackRequestDto
    {
        public Guid StablishmentId { get; set; } = Guid.Empty;
        public Guid UserId { get; set; } = Guid.Empty;
        public string Comment { get; set; } = string.Empty;


        public Feedback.OverallRating OverallRating { get; set; }
        public Feedback.ParkingRating ParkingRating { get; set; }
        public Feedback.WifiRating WifiRating { get; set; }
        public Feedback.PlugRating PlugRating { get; set; }
        public Feedback.PriceRating PriceRating { get; set; }

    }
}
