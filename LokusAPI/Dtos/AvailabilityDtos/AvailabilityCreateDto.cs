namespace LokusAPI.Dtos.AvailabilityDtos
{
    public class AvailabilityCreateDto
    {
        public Guid SpaceId { get; set; }
        public DayOfWeek DiaSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
    }
}
