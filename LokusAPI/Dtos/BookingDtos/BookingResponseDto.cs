namespace LokusAPI.Dtos.BookingDtos
{
    public class BookingResponseDto
    {
        public Guid Id { get; set; }
        public Guid SpaceId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public string Status { get; set; } = string.Empty;

        public BookingResponseDto() { }
        public BookingResponseDto(Guid id, Guid spaceId, Guid customerId, DateTime data, TimeSpan horaInicio, TimeSpan horaFim, string status)
        {
            Id = id;
            SpaceId = spaceId;
            CustomerId = customerId;
            Data = data;
            HoraInicio = horaInicio;
            HoraFim = horaFim;
            Status = status;
        }
    }
}
