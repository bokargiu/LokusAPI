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
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Image> Images { get; set; } = new List<Image>(); //foto perfil
        public ICollection<Subscription> History { get; set; } = new List<Subscription>(); //histórico de assinaturas
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
        public ICollection<Stablishment> Stablishments { get; set; } = new List<Stablishment>();

        //não mapeado no banco de dados, campo calculado
        [NotMapped]
        public Subscription CurrentSubscription { get; set; }

    }
}
