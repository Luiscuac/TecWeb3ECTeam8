using Microsoft.EntityFrameworkCore;
using TecWebGrupo8.Data;
using TecWebGrupo8.Models;

namespace TecWebGrupo8.Repositories;

public class GuestRepository : IGuestRepository
{
    private readonly AppDbContext _context;
    public GuestRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Guest>> GetAll()
        => await _context.Guests.AsNoTracking().ToListAsync();

    public async Task<Guest?> GetById(Guid id)
        => await _context.Guests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task Add(Guest guest)
    {
        await _context.Guests.AddAsync(guest);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var existing = await _context.Guests.FirstOrDefaultAsync(x => x.Id == id);
        if (existing is null) return;
        _context.Guests.Remove(existing);
        await _context.SaveChangesAsync();
    }
}
