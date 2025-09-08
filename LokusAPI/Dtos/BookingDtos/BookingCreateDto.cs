namespace LokusAPI.Dtos.BookingDtos
{
    public class BookingCreateDto
    {
        public Guid SpaceId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }

        public BookingCreateDto() { }

        public BookingCreateDto(Guid spaceId, Guid customerId, DateTime data, TimeSpan horaInicio, TimeSpan horaFim)
        {
            SpaceId = spaceId;
            CustomerId = customerId;
            Data = data;
            HoraInicio = horaInicio;
            HoraFim = horaFim;
        }
    }
}
