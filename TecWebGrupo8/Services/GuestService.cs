using TecWebGrupo8.Models;
using TecWebGrupo8.Models.dtos;
using TecWebGrupo8.Repositories;

namespace TecWebGrupo8.Services;

public class GuestService : IGuestService
{
    private readonly IGuestRepository _repo;
    public GuestService(IGuestRepository repo) => _repo = repo;

    public async Task<Guest> Create(CreateGuestDto dto)
    {
        var name = dto.FullName?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidOperationException("FullName is required.");
        if (name.Length > 200)
            throw new InvalidOperationException("FullName must be 200 characters or fewer.");

        var guest = new Guest
        {
            Id = Guid.NewGuid(),
            FullName = name,
            Confirmed = dto.Confirmed
        };

        await _repo.Add(guest);
        return guest;
    }

    public async Task<bool> Delete(Guid id)
    {
        var existing = await _repo.GetById(id);
        if (existing is null) return false;
        await _repo.Delete(id);
        return true;
    }

    public Task<IEnumerable<Guest>> GetAll() => _repo.GetAll();
    public Task<Guest?> GetById(Guid id) => _repo.GetById(id);
}
