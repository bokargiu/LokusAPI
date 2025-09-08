namespace LokusAPI.Dtos.StablishmentDto
{
    public class StablishmentGalleryDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string Base64Data { get; set; } = string.Empty;
    }
}
