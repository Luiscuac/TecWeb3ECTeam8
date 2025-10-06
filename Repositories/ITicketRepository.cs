using TecWebGrupo8.Models;

namespace TecWebGrupo8.Repositories
{
    public interface ITicketRepository
    {
        Task <IEnumerable<Ticket>> GetAll();
        Task<Ticket?> GetById(Guid id);
        Task Add(Ticket ticket);
        Task Delete(Guid id);

    }
}
