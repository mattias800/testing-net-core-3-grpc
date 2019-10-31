namespace TimeTableEventConsumer.Domains.PublishDeparture.Entities
{
    public class DepartureEntity
    {
        public string Id { get; set; }
        public string ShipCode { get; set; }
        public TerminalScheduleVO DepartureSchedule { get; set; }
        public TerminalScheduleVO ArrivalSchedule { get; set; }
        public LocalDateTime LoadingTime { get; set; }
        public LocalDateTime RampTime { get; set; }
    }
}