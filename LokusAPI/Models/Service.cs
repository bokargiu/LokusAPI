using System.Text.Json.Serialization;

namespace LokusAPI.Models
{
    public class Service
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        [JsonIgnore]
        public Stablishment Stablishment { get; set; }
    }
}
