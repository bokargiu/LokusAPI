using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace LokusAPI.Models
{
    public class Category
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; } = string.Empty;

        public Guid StablishmentId { get; set; } 
        public Stablishment Stablishment { get; set; }
    }
}
