    using LokusAPI.Models;

    namespace LokusAPI.Dtos.SpaceDtos.SpaceDto
    {
        public class SpaceCreateDto
        {
            public Guid StablishmentId { get; set; }
            public string Name { get; set; } = string.Empty;
            public int Capacity { get; set; }
            public string? Description { get; set; }
            public decimal Price { get; set; }
            public PriceEnum PriceEnum { get; set; }

            public SpaceCreateDto() { }

            public SpaceCreateDto(string name, int capacity, string? description, decimal price, PriceEnum priceEnum)
            {
                Name = name;
                Capacity = capacity;
                Description = description;
                Price = price;
                PriceEnum = priceEnum;
            }
        }
    }
