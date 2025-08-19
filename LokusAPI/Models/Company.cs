using System.Text.Json.Serialization;

namespace LokusAPI.Models
{
    public class Company
    {
        public Guid Id { get; set; } = new Guid();
        public string NameCompany { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string ContactOther { get; set; } = string.Empty;

        public User User { get; set; }
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Image> Images { get; set; } = new List<Image>();

    }
}
