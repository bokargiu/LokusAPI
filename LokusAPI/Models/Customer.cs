using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations.Schema;
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

        //relação 1:1 
        public User User { get; set; }

        //relações 1:N
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Image> Images { get; set; } = new List<Image>();
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

        //histórico das assinaturas
        public ICollection<Subscription> History { get; set; } = new List<Subscription>();

        //Assinatura atual, não mapeaa no banco
        [NotMapped]
        public Subscription CurrentSubscription { get; set; }

        //reservas do cliente
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();


    }
}
