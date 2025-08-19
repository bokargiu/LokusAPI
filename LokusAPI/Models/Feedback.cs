using System.Text.Json.Serialization;

namespace LokusAPI.Models
{
    public class Feedback
    {
        public Guid Id { get; set; } = new Guid();
        public string Descrription { get; set; } = string.Empty;
        public double PlugsEvaluation { get; set; }
        public double ParkingEvaluation { get; set; }
        public double WifiEvaluation { get; set; }
        public double PriceEvaluation { get; set; }
        [JsonIgnore]
        public Stablishment Stablishment { get; set; }
        public Client Client { get; set; }
    }
}
