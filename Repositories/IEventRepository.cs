using TecWeb3ECTeam8.Models;

namespace TecWeb3ECTeam8.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAll();
        Task<Event?> GetById(Guid id);
        Task Add(Event evt);
        Task Delete(Guid id);
    }
}
