using TecWebGrupo8.Models;

namespace TecWebGrupo8.Repositories;

public interface IGuestRepository
{
    Task<IEnumerable<Guest>> GetAll();
    Task<Guest?> GetById(Guid id);
    Task Add(Guest guest);
    Task Delete(Guid id);
}
