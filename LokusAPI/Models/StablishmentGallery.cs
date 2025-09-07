namespace LokusAPI.Models
{
    public class StablishmentGallery
    {
        public Guid Id { get; set; } = new Guid();
        public string FileName { get; set; } = string.Empty;
        public byte[] Data { get; set; } = Array.Empty<byte>();

        //chave estrangeira FK
        public Guid StablishmentId { get; set; } 
        public Stablishment Stablishment { get; set; }
    }
}
