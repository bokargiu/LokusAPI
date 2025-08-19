namespace LokusAPI.Models
{
    public class Stablishment
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
        public Company Company { get; set; }
        public Address Address { get; set; }
        public Category? Category { get; set; }
        public ScoreForStablishment Score { get; set; } = new ScoreForStablishment();
        public ICollection<Feedback> Feedback { get; set; } = new List<Feedback>();
        public ICollection<Service> Services { get; set; } = new List<Service>();
    }
}
