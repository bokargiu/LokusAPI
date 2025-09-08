using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LokusAPI.Models
{
    public class Payment
    {

            [Key]
            public Guid Id { get; set; }

            [ForeignKey("Booking")]
            public Guid ReservaId { get; set; }

            [Column(TypeName = "decimal(10,2)")]
            public decimal Price { get; set; }

            //public string Metodo { get; set; } = "pix"; // pix, cartão
            //public PaymentStatus Status { get; set; } = PaymentStatus.Pendente;

            public virtual Booking? Booking { get; set; }
        
    }
}
