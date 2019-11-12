using System.Linq;
using System.Threading.Tasks;
using Timetable.Events;
using TimeTableService.Common.Util.DateFormat;
using TimeTableService.Repositories;

namespace TimeTableService.Domains.PublishDeparture.Consumers
{
    public class DepartureChangedPlannedArrivalDateConsumer
    {
        private readonly IDepartureRepository _departureRepository;

        public DepartureChangedPlannedArrivalDateConsumer(IDepartureRepository departureRepository)
        {
            _departureRepository = departureRepository;
        }

        public async Task HandleEvent(DepartureChangedPlannedArrivalDateEvent depEvent)
        {
            var depList = await _departureRepository.FetchByIds(new[] {depEvent.DepartureId});
            var dep = depList.First();
            dep.ArrivalSchedule.PlannedTime.Date = DateParser.ParseDate(depEvent.Date);
            await _departureRepository.Update(dep);
        }
    }
}