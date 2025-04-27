using Ferovi.Models.EF;

namespace Ferovi.Models.Repositories.Interfaces
{
    public interface IUsuariosHistorialAccesosRepository
    {
        Task CreateAsync(UsuariosHistorialAccesos registro);
        Task DeleteAsync(int id);
        Task<IEnumerable<UsuariosHistorialAccesos>> GetAllAsync();
        Task<IEnumerable<UsuariosHistorialAccesos>> GetAllByDatatablesFiltersAsync(int start, int length, string searchValue, string filterUserName, string filterFirstLastName, string filterSecondLastName, string filterAlias, DateTime? filterDate, string sortColumn, string sortDirection);
        Task<UsuariosHistorialAccesos> GetByIdAsync(int id);
        Task UpdateAsync(UsuariosHistorialAccesos registro);
    }
}