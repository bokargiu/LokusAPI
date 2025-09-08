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
        public Address Address { get; set; }
        public User User { get; set; }

        public Guid? ProfileImageId { get; set; }
        public Image? ProfileImage { get; set; }

        //relaes 1:N
        public ICollection<Image> Images { get; set; } = new List<Image>();
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
        public Subscription CurrentSubscription { get; set; }

        //histrico das assinaturas
        public ICollection<Subscription> History { get; set; } = new List<Subscription>();

        //reservas do cliente
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();


    }
}
