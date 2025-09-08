namespace LokusAPI.Dtos.AvailabilityDtos
{
    public class AvailabilityReadDto
    {
        public Guid Id { get; set; }
        public DayOfWeek DiaSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
