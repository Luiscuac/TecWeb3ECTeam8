using Microsoft.EntityFrameworkCore;
using TecWeb3ECTeam8.Models;
using TecWebGrupo8.Data;


namespace TecWeb3ECTeam8.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;
        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Event evt)
        {
            await _context.Events.AddAsync(evt);
        }

        public async Task Delete(Guid id)
        {
            var evt = await _context.Events.FirstOrDefaultAsync(x => x.Id == id);
            if (evt != null)
            {
                _context.Events.Remove(evt);
            }

        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event?> GetById(Guid id)
        {
            return await _context.Events.FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
