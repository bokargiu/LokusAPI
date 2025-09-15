namespace LokusAPI.Dtos.AddressDtos
{
    public class AddressCreateDto
    {
        //cria endereço
        public string Road { get; set; } = string.Empty;
        public string Complement { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;

        public Guid StablishmentId { get; set; }

        public AddressCreateDto() { }

        public AddressCreateDto(string road, string complement, string neighborhood, string city, string state, string cep, Guid stablishmentId)
        {
            Road = road;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Cep = cep;
            StablishmentId = stablishmentId;
        }
    }
}
