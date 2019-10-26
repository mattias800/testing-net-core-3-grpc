using System.Threading.Tasks;
using TimeTableEventConsumer.Domains.PublishDeparture.Entities;

namespace TimeTableEventConsumer.Repositories
{
    public interface IDepartureRepository
    {
        Task StoreNewDeparture(DepartureEntity departure);
        Task UpdateDeparture(DepartureEntity departure);
        Task DeleteDepartureById(string departureId);
        Task<DepartureEntity> FetchDepartureById(string departureId);
    }
}