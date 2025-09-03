namespace LokusAPI.Dtos
{
    public class SpaceDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Capacity { get; set; }

        public decimal PricePerHour { get; set; }

        SpaceDto() { }

        SpaceDto(string name, string description, int capacity, decimal pricePerHour)
        {
            Name = name;
            Description = description;
            Capacity = capacity;
            PricePerHour = pricePerHour;
        }
    }
}
