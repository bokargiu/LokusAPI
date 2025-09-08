using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace LokusAPI.Dtos.FeedbackDto
{
    public class FeedbackDto
    {
        public string Comment { get; set; } = string.Empty;
        public int OverallRating { get; set; } = 0;
        public int ParkingRating { get; set; } = 0;
        public int WifiRating { get; set; } = 0;
        public int PlugRating { get; set; } = 0;
        public int PriceRating { get; set; } = 0;

        public string Username { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public FeedbackDto() { }

        public FeedbackDto(string comment, int overallRating, int parkingRating, int wifiRating, int plugRating, int priceRating, string username, DateTime createdAt)
        {
            Comment = comment;
            OverallRating = overallRating;
            ParkingRating = parkingRating;
            WifiRating = wifiRating;
            PlugRating = plugRating;
            PriceRating = priceRating;
            Username = username;
            CreatedAt = createdAt;
        }


    }
}
