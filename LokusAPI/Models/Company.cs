using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LokusAPI.Models
{
    public class Company
    {
        public Guid Id { get; set; } = new Guid();
        public string NameCompany { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string ContactOther { get; set; } = string.Empty;

        //relacionamento 1:1
        public Guid UserId { get; set; }
        public User User { get; set; }

        //relacionamento 1:N
        [JsonIgnore]
        public ICollection<Stablishment> Stablishments { get; set; } = new List<Stablishment>();
        public Subscription CurrentSubscription { get; set; } //assintura atual

    }
}
