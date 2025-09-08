using Microsoft.EntityFrameworkCore.Diagnostics;

namespace LokusAPI.Dtos.StablishmentDto
{
    public class StablishmentCreateDto
    {
        //para criar o stablishment e associar a uma company
        public string Name { get; set; } = string.Empty;
        public string VirtualName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;

        public AddressCreateDto Address { get; set; } = new AddressCreateDto();

        public StablishmentCreateDto() { }

        public StablishmentCreateDto(string name, string virtualName, string description, string contact, AddressCreateDto address)
        {
            Name = name;
            VirtualName = virtualName;
            Description = description;
            Contact = contact;
            Address = address;
        }
    }
}
