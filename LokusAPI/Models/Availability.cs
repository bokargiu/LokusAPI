namespace LokusAPI.Models
{
    public class Availability
    {
        public Guid Id { get; set; }
        public Guid SpaceId { get; set; }
        public DayOfWeek DiaSemana { get; set; } // agenda fixa por dia da semana
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public AvailabilityStatus Status { get; set; } = AvailabilityStatus.Disponivel;
        public virtual Space? Space { get; set; }
    }

    public enum AvailabilityStatus
    {
        Disponivel = 1,
        Indisponivel = 2
    }
}
