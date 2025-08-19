using System.Text.Json.Serialization;

namespace LokusAPI.Models
{
    public class Category
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<Stablishment> Stablishments { get; set; } = new List<Stablishment>();
    }
}
