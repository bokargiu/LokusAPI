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

        public List<StablishmentGalleryDto> Galleries { get; set; } = new List<StablishmentGalleryDto>();

        public StablishmentResponseDto() { }

        public StablishmentResponseDto(Guid id, string name, string virtualName, string description, string contact, Guid companyId, List<StablishmentGalleryDto> galleries)
        {
            Id = id;
            Name = name;
            VirtualName = virtualName;
            Description = description;
            Contact = contact;
            CompanyId = companyId;
            Galleries = galleries;
        }
    }
}
