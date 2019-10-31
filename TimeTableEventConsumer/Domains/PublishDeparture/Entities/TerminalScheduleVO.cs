namespace TimeTableEventConsumer.Domains.PublishDeparture.Entities
{
    public class TerminalScheduleVO
    {
        public string TerminalCode { get; set; }
        public LocalDateTime PlannedTime { get; set; }
        public LocalDateTime EstimatedTime { get; set; }
        public LocalDateTime ActualTime { get; set; }
        
    }
}