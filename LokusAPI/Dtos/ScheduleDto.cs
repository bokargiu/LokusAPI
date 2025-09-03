namespace LokusAPI.Dtos
{
    public class ScheduleDto
    {
        public Guid SpaceId { get; set; }
        public string DayOfWeek { get; set; }
        public string Time { get; set; }

        ScheduleDto() { }

        ScheduleDto(Guid spaceId, string dayOfWeek, string time)
        {
            SpaceId = spaceId;
            DayOfWeek = dayOfWeek;
            Time = time;
        }
    }
}
