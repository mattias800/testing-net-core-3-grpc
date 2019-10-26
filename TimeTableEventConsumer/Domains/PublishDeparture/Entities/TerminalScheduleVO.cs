namespace TimeTableEventConsumer.Domain
{
    public class TerminalScheduleVO
    {
        public string TerminalCode { get; set; }
        public string PlannedTime { get; set; }
        public string EstimatedTime { get; set; }
        public string ActualTime { get; set; }
        
    }
}