using TecWeb3ECTeam8.Models;
using TecWeb3ECTeam8.Models.dtos;

namespace TecWeb3ECTeam8.Services
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAll();
        Task<Event?> GetById(Guid id);
        Task<Event> Create(CreateEventDto dto);
        Task<bool> Delete(Guid id);
    }
}
