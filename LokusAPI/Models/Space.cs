using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LokusAPI.Models
{
    public class Space
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("Stablishment")]
        public Guid StablishmentId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public int Capacity { get; set; }

        public string? Description { get; set; }

        // preço pode ser decimal para suportar valores com vírgula
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
 
        // valores possíveis: "hora", "dia"
        [Required]
        public PriceEnum PriceEnum { get; set; }

        //relacionamento 1:N
        public virtual Stablishment? Stablishment { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }

}

