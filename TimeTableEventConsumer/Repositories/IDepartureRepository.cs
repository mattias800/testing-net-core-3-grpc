using System.Threading.Tasks;
using TimeTableEventConsumer.Domain;

namespace TimeTableEventConsumer.Repositories
{
    public interface IDepartureRepository
    {
        Task StoreNewDeparture(DepartureEntity departure);
        Task UpdateDeparture(DepartureEntity departure);
        Task DeleteDepartureById(string departureId);
        Task<Departure> FetchDepartureById(string departureId);
    }
}