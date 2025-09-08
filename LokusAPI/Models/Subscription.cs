using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace LokusAPI.Models
{
    public enum SubscriptionType
    {
        Customer,
        Company
    }
    public class Subscription
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0.0m;

        [Required(ErrorMessage = "O tipo é obrigatório")]
        [RegularExpression("^(Customer|Company)$", ErrorMessage = "Tipo de assinatura inválido. Use 'Customer' ou 'Company'.")]
        public string Type { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
        public ICollection<Company> Companies { get; set; } = new List<Company>();


    }
}
