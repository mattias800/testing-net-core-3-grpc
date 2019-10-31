using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using TimeTableEventConsumer.Domains.PublishDeparture.Entities;

namespace TimeTableEventConsumer.Repositories
{
    public interface IDepartureRepository
    {
        Task Insert(DepartureEntity departure);
        Task Update(DepartureEntity departure);
        Task Delete(string departureId);
        Task<IEnumerable<DepartureEntity>> FetchByIds(IEnumerable<string> departureIds);

        Task<IEnumerable<DepartureEntity>> SearchByPlannedDepartureDate(DateTime startDate, DateTime endDate);
    }
}
