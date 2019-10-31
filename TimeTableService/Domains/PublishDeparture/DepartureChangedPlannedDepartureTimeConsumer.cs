using System.Linq;
using System.Threading.Tasks;
using Timetable.Events;
using TimeTableEventConsumer.Repositories;

namespace TimeTableEventConsumer.Domains.PublishDeparture
{
    public class DepartureChangedPlannedDepartureTimeConsumer
    {
        private readonly IDepartureRepository _departureRepository;

        public DepartureChangedPlannedDepartureTimeConsumer(IDepartureRepository departureRepository)
        {
            _departureRepository = departureRepository;
        }

        public async Task HandleEvent(DepartureChangedPlannedDepartureTimeEvent depEvent)
        {
            var depList = await _departureRepository.FetchByIds(new[] {depEvent.DepartureId});
            var dep = depList.First();
            dep.DepartureSchedule.PlannedTime.Time = depEvent.Time;
            await _departureRepository.Update(dep);
        }
    }
}