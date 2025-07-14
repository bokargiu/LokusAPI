namespace LokusAPI.Models
{
    public class Image
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; }

        public Guid? ClientId { get; set; }
        public Client? Client { get; set; }

        public Guid? CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}