namespace LokusAPI.Dtos.SpaceDto
{
    public class SpaceDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Capacity { get; set; }

        public decimal Price { get; set; }

        SpaceDto() { }

        SpaceDto(string name, string description, int capacity, decimal price)
        {
            Name = name;
            Description = description;
            Capacity = capacity;
            Price = price;
        }
    }
}
