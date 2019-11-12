using System.Threading.Tasks;
using AutoMapper;
using Timetable.Events;
using TimeTableService.Domains.PublishDeparture.Entities;
using TimeTableService.Repositories;

namespace TimeTableService.Domains.PublishDeparture.Consumers
{
    public class DeparturePublishedConsumer
    {
        private readonly IDepartureRepository _departureRepository;
        private readonly IMapper _mapper;

        public DeparturePublishedConsumer(
            IDepartureRepository departureRepository,
            IMapper mapper)
        {
            _departureRepository = departureRepository;
            _mapper = mapper;
        }

        public Task HandleEvent(DeparturePublishedEvent departurePublishedEvent)
        {
            var departure = _mapper.Map<Departure, DepartureEntity>(departurePublishedEvent.Departure);
            return _departureRepository.Insert(departure);
        }
    }
}