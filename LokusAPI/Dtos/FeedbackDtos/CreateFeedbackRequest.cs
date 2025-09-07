namespace LokusAPI.Dtos.FeedbackDto
{
    public class CreateFeedbackRequest
    {
        public Guid CompanyId { get; set; } = Guid.Empty;
        public Guid UserId { get; set; } = Guid.Empty;
        public string Comment { get; set; } = string.Empty;

        public int OverallRating { get; set; } = 0;
        public int ParkingRating { get; set; } = 0;
        public int WifiRating { get; set; } = 0;
        public int PlugRating { get; set; } = 0;
        public int PriceRating { get; set; } = 0;

    }
}
