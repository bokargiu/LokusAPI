using LokusAPI.Dtos.AddressDtos;
using LokusAPI.Models;

namespace LokusAPI.Dtos.StablishmentDto
{
    public class StablishmentResponseDto
    {
        // Para exibir detalhes do estabelecimento no futuro
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string VirtualName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;

        public Guid CompanyId { get; set; }

        public AddressResponseDto? Address { get; set; } = null!;

        public List<StablishmentGalleryDto> Galleries { get; set; } = new List<StablishmentGalleryDto>();

        public StablishmentResponseDto() { }

        public StablishmentResponseDto(Stablishment stablishment)
        {
            Id = stablishment.Id;
            Name = stablishment.Name;
            VirtualName = stablishment.VirtualName;
            Description = stablishment.Description;
            Contact = stablishment.Contact;
            CompanyId = stablishment.CompanyId;
            Galleries = new List<StablishmentGalleryDto>();
            Address = stablishment.Address != null ? new AddressResponseDto(stablishment.Address) : null;
        }
    }
}
