namespace LokusAPI.Dtos.SpaceDto
{
    public class SpaceReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        //public string UnidadePreco { get; set; } = string.Empty;

        public SpaceReadDto() { }

        public SpaceReadDto(Guid id, string name, int capacity, string? description, decimal price)
        {
            Id = id;
            Name = name;
            Capacity = capacity;
            Description = description;
            Price = price;
            //UnidadePreco = unidadePreco;
        }
    }
}
