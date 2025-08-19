namespace LokusAPI.Models
{
    public class ScoreForStablishment
    {
        public Guid Id { get; set; } = new Guid();
        public double PlugsRating { get; set; } = 0.0;
        public double ParkingRating { get; set; } = 0.0;
        public double WifiRating { get; set; } = 0.0;
        public double PriceRating { get; set; } = 0.0;

    }
}
