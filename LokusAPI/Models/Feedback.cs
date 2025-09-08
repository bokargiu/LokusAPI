using static LokusAPI.Models.Feedback;

namespace LokusAPI.Models
{
    public class Feedback
    {
        public Guid Id { get; set; } = new Guid();

        public Guid StablishmentId { get; set; } = Guid.Empty;
        public Stablishment Stablishment { get; set; } = null!;

        public Guid UserId { get; set; } = Guid.Empty;
        public User User { get; set; } = null!;

        //Comentário 
        public string Comment { get; set; } = string.Empty;

        //Avaliacoes
        public OverallRating OverallRatings { get; set; }
        public ParkingRating ParkingRatings { get; set; }
        public WifiRating WifiRatings { get; set; }
        public PlugRating PlugRatings { get; set; }
        public PriceRating PriceRatings { get; set; }


        public enum OverallRating
        {
            VeryPoor = 1,
            Poor = 2,
            Average = 3,
            Good = 4,
            Excellent = 5
        }
        public enum ParkingRating
        {
            VeryPoor = 1,
            Poor = 2,
            Average = 3,
            Good = 4,
            Excellent = 5
        }
        public enum WifiRating
        {
            VeryPoor = 1,
            Poor = 2,
            Average = 3,
            Good = 4,
            Excellent = 5
        }
        public enum PlugRating
        {
            VeryPoor = 1,
            Poor = 2,
            Average = 3,
            Good = 4,
            Excellent = 5
        }
        public enum PriceRating
        {
            VeryPoor = 1,
            Poor = 2,
            Average = 3,
            Good = 4,
            Excellent = 5
        }


        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    }
}
