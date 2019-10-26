using System.Threading.Tasks;
using Timetable.Events;
using TimeTableEventConsumer.Domain.Transformers;
using TimeTableEventConsumer.Repositories;

namespace TimeTableEventConsumer.PublishDeparture
{
    public class PublishDepartureConsumer
    {
        private readonly IDepartureRepository _departureRepository;
        private readonly DepartureTransformer _departureTransformer;

        public PublishDepartureConsumer(IDepartureRepository departureRepository,
            DepartureTransformer departureTransformer)
        {
            _departureRepository = departureRepository;
            _departureTransformer = departureTransformer;
        }

        public Task handleEvent(PublishDepartureEvent publishDepartureEvent)
        {
            var departure =
                _departureTransformer.transformEventDepartureToDepartureEntity(publishDepartureEvent.Departure);
            return _departureRepository.StoreNewDeparture(departure);
        }
    }
}