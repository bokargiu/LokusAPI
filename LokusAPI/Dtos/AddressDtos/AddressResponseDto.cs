using LokusAPI.Models;

namespace LokusAPI.Dtos.AddressDtos
{
    public class AddressResponseDto
    {
        public Guid Id { get; set; }
        public string Road { get; set; } = string.Empty;
        public string Complement { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;

        public AddressResponseDto(Address address)
        {
            Id = address.Id;
            Road = address.Road;
            Complement = address.Complement;
            Neighborhood = address.Neighborhood;
            City = address.City;
            State = address.State;
            Cep = address.Cep;
        }
    }
}
