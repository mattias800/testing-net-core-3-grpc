using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTableEventConsumer.Domains.PublishDeparture.Entities;

namespace TimeTableEventConsumer.Repositories
{
    public interface IDepartureRepository
    {
        Task Insert(DepartureEntity departure);
        Task Update(DepartureEntity departure);
        Task Delete(string departureId);
        Task<IEnumerable<DepartureEntity>> FetchByIds(string[] departureIds);
    }
}
