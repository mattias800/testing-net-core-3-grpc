namespace TimeTableEventConsumer.Domain.Transformers
{
    public class DepartureTransformer
    {
        public DepartureEntity transformEventDepartureToDepartureEntity(Departure eventDeparture)
        {
            return new DepartureEntity()
            {
                Id = eventDeparture.Id,
                LoadingTime = eventDeparture.LoadingTime,
                RampTime = eventDeparture.RampTime,
                ShipCode = eventDeparture.ShipCode,
                ArrivalSchedule = new TerminalScheduleVO()
                {
                    ActualTime = eventDeparture.ArrivalSchedule.ActualTime,
                    EstimatedTime = eventDeparture.ArrivalSchedule.EstimatedTime,
                    PlannedTime = eventDeparture.ArrivalSchedule.PlannedTime,
                    TerminalCode = eventDeparture.ArrivalSchedule.TerminalCode,
                },
                DepartureSchedule = new TerminalScheduleVO()
                {
                    ActualTime = eventDeparture.DepartureSchedule.ActualTime,
                    EstimatedTime = eventDeparture.DepartureSchedule.EstimatedTime,
                    PlannedTime = eventDeparture.DepartureSchedule.PlannedTime,
                    TerminalCode = eventDeparture.DepartureSchedule.TerminalCode,
                },
            };
        }
    }
}