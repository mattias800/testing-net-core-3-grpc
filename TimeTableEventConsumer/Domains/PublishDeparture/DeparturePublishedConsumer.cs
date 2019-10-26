using System.Threading.Tasks;
using Timetable.Events;
using TimeTableEventConsumer.Domains.PublishDeparture.Transformers;
using TimeTableEventConsumer.Repositories;

namespace TimeTableEventConsumer.Domains.PublishDeparture
{
    public class DeparturePublishedConsumer
    {
        private readonly IDepartureRepository _departureRepository;
        private readonly DepartureTransformer _departureTransformer;

        public DeparturePublishedConsumer(IDepartureRepository departureRepository,
            DepartureTransformer departureTransformer)
        {
            _departureRepository = departureRepository;
            _departureTransformer = departureTransformer;
        }

        public Task HandleEvent(DeparturePublishedEvent departurePublishedEvent)
        {
            var departure =
                _departureTransformer.transformEventDepartureToDepartureEntity(departurePublishedEvent.Departure);
            return _departureRepository.StoreNewDeparture(departure);
        }
    }
}