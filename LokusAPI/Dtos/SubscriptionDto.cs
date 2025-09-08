using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace LokusAPI.Dtos
{
    public class SubscriptionDto
    {
        public string Name { get; set; } = string.Empty;     
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0.0m;
        public string Type { get; set; } = string.Empty;

        public SubscriptionDto() { }

        public SubscriptionDto(string name, string description, decimal price, string type)
        {
            Name = name;
            Description = description;
            Price = price;
            Type = type;
        }


    }
}
