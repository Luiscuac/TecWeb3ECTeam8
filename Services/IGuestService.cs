using TecWebGrupo8.Models;
using TecWebGrupo8.Models.dtos;

namespace TecWebGrupo8.Services;

public interface IGuestService
{
    Task<Guest> Create(CreateGuestDto dto);
    Task<bool> Delete(Guid id);
    Task<IEnumerable<Guest>> GetAll();
    Task<Guest?> GetById(Guid id);
}
