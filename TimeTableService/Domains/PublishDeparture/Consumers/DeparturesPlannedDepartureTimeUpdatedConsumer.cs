using System.Linq;
using System.Threading.Tasks;
using Timetable.Events;
using TimeTableService.Repositories;

namespace TimeTableService.Domains.PublishDeparture.Consumers
{
    public class DeparturesPlannedDepartureTimeUpdatedConsumer
    {
        private readonly IDepartureRepository _departureRepository;

        public DeparturesPlannedDepartureTimeUpdatedConsumer(IDepartureRepository departureRepository)
        {
            _departureRepository = departureRepository;
        }

        public async Task HandleEvent(DeparturesPlannedDepartureTimeUpdated depEvent)
        {
            var depList = await _departureRepository.FetchByIds(new[] {depEvent.DepartureId});
            var dep = depList.First();
            dep.DepartureSchedule.PlannedTime.Time = depEvent.Time;
            await _departureRepository.Update(dep);
        }
    }
}