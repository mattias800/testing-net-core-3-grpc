namespace TimeTableService.Domains.PublishDeparture.Entities
{
    public class TerminalScheduleVO
    {
        public string TerminalCode { get; set; }
        public LocalDateTimeVO PlannedTime { get; set; }
        public LocalDateTimeVO EstimatedTime { get; set; }
        public LocalDateTimeVO ActualTime { get; set; }
        
    }
}