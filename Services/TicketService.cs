using TecWebGrupo8.Models;
using TecWebGrupo8.Models.dtos;
using TecWebGrupo8.Repositories;

namespace TecWebGrupo8.Services
{
    public class TicketService: ITicketService
    {
        
        private readonly ITicketRepository _repo;
        public TicketService(ITicketRepository repo) => _repo = repo;

        public async Task<Ticket> Create(CreateTicketDto dto)
        {
            var ticket = new Ticket { Id = Guid.NewGuid(), notes = dto.notes };
            await _repo.Add(ticket);
            return ticket;
        }

        public async Task<bool> Delete(Guid id)
        {
            var existing = await _repo.GetById(id);
            if (existing is null) return false;
            await _repo.Delete(id);
            return true;
        }

        public Task<IEnumerable<Ticket>> GetAll() => _repo.GetAll();
        public Task<Ticket?> GetById(Guid id) => _repo.GetById(id);
        
    }

}

