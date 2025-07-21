using System.Text.Json.Serialization;

namespace LokusAPI.Models
{
    public class Image
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; }

        [JsonIgnore]
        public Client? Client { get; set; }
        public Company? Company { get; set; }
    }
}