using TecWebGrupo8.Models;
using TecWebGrupo8.Models.dtos;

namespace TecWebGrupo8.Services
{
    public interface ITicketService
    {
        Task<Ticket> Create(CreateTicketDto dto);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<Ticket>> GetAll();
        Task<Ticket?> GetById(Guid id);
    }
}
