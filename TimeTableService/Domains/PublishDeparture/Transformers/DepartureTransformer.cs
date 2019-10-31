using TimeTableEventConsumer.Domains.PublishDeparture.Entities;

namespace TimeTableEventConsumer.Domains.PublishDeparture.Transformers
{
    public class DepartureTransformer
    {
        public DepartureEntity transformEventDepartureToDepartureEntity(Departure eventDeparture)
        {
            return new DepartureEntity()
;
        }
    }
}