using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Timetable.Events;
using TimeTableEventConsumer.Common.Util.DateFormat;
using TimeTableEventConsumer.Repositories;

namespace TimeTableEventConsumer.Domains.PublishDeparture.Consumers
{
    public class DepartureChangedPlannedDepartureDateConsumer
    {
        private readonly IDepartureRepository _departureRepository;

        public DepartureChangedPlannedDepartureDateConsumer(IDepartureRepository departureRepository)
        {
            _departureRepository = departureRepository;
        }

        public async Task HandleEvent(DepartureChangedPlannedDepartureDateEvent depEvent)
        {
            var depList = await _departureRepository.FetchByIds(new[] {depEvent.DepartureId});
            var dep = depList.First();
            dep.DepartureSchedule.PlannedTime.Date = DateParser.ParseDate(depEvent.Date);
            await _departureRepository.Update(dep);
        }
    }
}