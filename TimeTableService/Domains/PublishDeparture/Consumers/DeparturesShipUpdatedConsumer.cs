using System.Linq;
using System.Threading.Tasks;
using Timetable.Events;
using TimeTableService.Repositories;

namespace TimeTableService.Domains.PublishDeparture.Consumers
{
    public class DeparturesShipUpdatedConsumer
    {
        private readonly IDepartureRepository _departureRepository;

        public DeparturesShipUpdatedConsumer(IDepartureRepository departureRepository)
        {
            _departureRepository = departureRepository;
        }

        public async Task HandleEvent(DeparturesShipUpdated depEvent)
        {
            var depList = await _departureRepository.FetchByIds(new[] {depEvent.DepartureId});
            var dep = depList.First();
            dep.ShipCode = depEvent.ShipCode;
            await _departureRepository.Update(dep);
        }
    }
}