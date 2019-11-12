namespace TimeTableService.Domains.PublishDeparture.Entities
{
    public class DepartureEntity
    {
        public string Id { get; set; }
        public string ShipCode { get; set; }
        public TerminalScheduleVO DepartureSchedule { get; set; }
        public TerminalScheduleVO ArrivalSchedule { get; set; }
        public LocalDateTimeVO LoadingTime { get; set; }
        public LocalDateTimeVO RampTime { get; set; }
    }
}