using Ferovi.Models.EF;

namespace Ferovi.Models.Repositories.Interfaces
{
    public interface IUsuariosRepository
    {
        Task CreateAsync(Usuarios users);
        Task DeleteAsync(int id);
        Task<IEnumerable<Usuarios>> GetAllAsync();
        Task<IEnumerable<Usuarios>> GetAllByDatatablesFiltersAsync(int start, int length, string searchValue, string filterUserName, string filterFirstLastName, string filterSecondLastName, string filterAlias, string filterEmail, string sortColumn, string sortDirection);
        Task<Usuarios> GetByIdAsync(int id);
        Task UpdateAsync(Usuarios users);
    }
}