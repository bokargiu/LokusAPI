namespace LokusAPI.Models
{
    public class Feedback
    {
        public Guid Id { get; set; } = new Guid();

        public Guid CompanyId { get; set; } = Guid.Empty;
        public Company Company { get; set; } = null!;

        public Guid UserId { get; set; } = Guid.Empty;
        public User User { get; set; } = null!;

        //Comentário 
        public string Comment { get; set; } = string.Empty;

        //Avaliacoes
        public int OverallRating { get; set; } = 0;
        public int ParkingRating { get; set; } = 0;
        public int WifiRating { get; set; } = 0;
        public int PlugRating { get; set; } = 0;
        public int PriceRating { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    }
}
