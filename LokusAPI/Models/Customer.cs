using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;

namespace LokusAPI.Models
{
    public class Customer
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
        public DateOnly Birthday { get; set; }

        public User User { get; set; }
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Image> Images { get; set; } = new List<Image>();

    }
}
