using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTableService.Domains.PublishDeparture.Entities;
using TimeTableService.Repositories;

namespace TimeTableService.DataLayer.Repositories
{
    public class InMemoryDepartureRepository: IDepartureRepository
    {

        private readonly List<DepartureEntity> _departures = new List<DepartureEntity>();
        
        public Task Insert(DepartureEntity departure)
        {
            _departures.Add(departure);
            return Task.CompletedTask;
        }

        public Task Update(DepartureEntity departure)
        {
            var index = _departures.FindIndex(d => d.Id == departure.Id);
            _departures[index] = departure;
            return Task.CompletedTask;
        }

        public Task Delete(string departureId)
        {
            var index = _departures.FindIndex(d => d.Id == departureId);
            if (index >= 0)
            {
                _departures.RemoveAt(0);
            }
            return Task.CompletedTask;
        }

        public Task<IEnumerable<DepartureEntity>> FetchByIds(IEnumerable<string> departureIds)
        {
            return Task.FromResult(departureIds.Select(id => _departures.Find(d => d.Id == id)));
        }

        public Task<IEnumerable<DepartureEntity>> SearchByPlannedDepartureDate(DateTime startDate, DateTime endDate)
        {
            var list = _departures.Where(d => 
                d.DepartureSchedule.PlannedTime.Date >= startDate.Date &&
                d.DepartureSchedule.PlannedTime.Date <= endDate.Date);
            return Task.FromResult(list);
        }
    }
}