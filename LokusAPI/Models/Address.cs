using System.Text.Json.Serialization;

namespace LokusAPI.Models
{
    public class Address
    {
        public Guid Id { get; set; } = new Guid();
        public string Road { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Complement { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;

        [JsonIgnore]
        public Client? Client { get; set; }
        public Company? Company { get; set; }
    }
}
