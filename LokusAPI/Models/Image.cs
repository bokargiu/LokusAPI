using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace LokusAPI.Models
{
    public class Image
    {
        public Guid Id { get; set; } = new Guid();
        public byte[] ImageData { get; set; }

        [JsonIgnore]
        public Guid? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public Guid? CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}