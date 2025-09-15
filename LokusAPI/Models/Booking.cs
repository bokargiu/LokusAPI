using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LokusAPI.Models
{
    public class Booking
    {
        [Key]
        public Guid Id { get; set; }

        public Guid SpaceId { get; set; }

        public Guid CustomerId { get; set; }

        //datas e horários

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public TimeSpan HoraInicio { get; set; }

        [Required]
        public TimeSpan HoraFim { get; set; }

        //status da reserva
        [Required]
        public BookingStatus Status { get; set; } = BookingStatus.Pendente;

        public virtual Space? Space { get; set; }
        public virtual Customer? Customer { get; set; }
    }

    public enum BookingStatus
    {
        Pendente = 0,
        Confirmado = 1,
        Cancelado = 2
    }
}
