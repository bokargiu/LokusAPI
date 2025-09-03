using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LokusAPI.Models
{
    public class Space
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Capacity { get; set; } = 0;

        public decimal PricePerHour { get; set; } = 0.0m;

        [JsonIgnore]
        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    }
}
