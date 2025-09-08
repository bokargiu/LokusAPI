namespace LokusAPI.Dtos.StablishmentDto
{
    public class StablishmentGalleryCreateDto
    {
        public Guid StablishmentId { get; set; } // tem a id do estabelecimento
        public string FileName { get; set; } = string.Empty;
        public string Base64 { get; set; } = string.Empty;
    }
}
