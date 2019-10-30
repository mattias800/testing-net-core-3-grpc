using System.Linq;
using System.Threading.Tasks;
using Timetable.Events;
using TimeTableEventConsumer.Repositories;

namespace TimeTableEventConsumer.Domains.PublishDeparture
{
    public class DepartureChangedShipConsumer
    {
        private readonly IDepartureRepository _departureRepository;

        public DepartureChangedShipConsumer(IDepartureRepository departureRepository)
        {
            _departureRepository = departureRepository;
        }

        public async Task HandleEvent(DepartureChangedShipEvent depEvent)
        {
            var depList = await _departureRepository.FetchByIds(new [] { depEvent.DepartureId });
            var dep = depList.First();
            dep.ShipCode = depEvent.ShipCode;
            await _departureRepository.Update(dep);
        }
    }
}