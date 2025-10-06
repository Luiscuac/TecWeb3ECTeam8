using TecWebGrupo8.Data;
using TecWebGrupo8.Models;
using Microsoft.EntityFrameworkCore;
using System;
namespace TecWebGrupo8.Repositories
{
    public class TicketRepository: ITicketRepository
    {

        private readonly AppDbContext _context;

        public TicketRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
        }

        public async Task Delete(Guid id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
            }
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<Ticket?> GetById(Guid id)
        {
            return await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
        }
        
    }

}

