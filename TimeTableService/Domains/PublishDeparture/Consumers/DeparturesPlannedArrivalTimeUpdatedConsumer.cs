using System.Linq;
using System.Threading.Tasks;
using Timetable.Events;
using TimeTableService.Repositories;

namespace TimeTableService.Domains.PublishDeparture.Consumers
{
    public class DepartureChangedPlannedArrivalTimeConsumer
    {
        private readonly IDepartureRepository _departureRepository;

        public DepartureChangedPlannedArrivalTimeConsumer(IDepartureRepository departureRepository)
        {
            _departureRepository = departureRepository;
        }

        public async Task HandleEvent(DeparturesPlannedArrivalTimeUpdated depEvent)
        {
            var depList = await _departureRepository.FetchByIds(new[] {depEvent.DepartureId});
            var dep = depList.First();
            dep.ArrivalSchedule.PlannedTime.Time = depEvent.Time;
            await _departureRepository.Update(dep);
        }
    }
}