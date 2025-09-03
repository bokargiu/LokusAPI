using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LokusAPI.Models
{
    public class Schedule
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid SpaceId { get; set; }

        [ForeignKey("SpaceId")]
        public Space Space { get; set; } = null!; //Garantir que ele fenha preenchido 

        [Required]
        public string DayOfWeek { get; set; } = string.Empty;

        [Required]
        public string Time { get; set; } = string.Empty; 
    }
}
