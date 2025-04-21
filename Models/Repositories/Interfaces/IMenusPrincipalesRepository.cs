using Ferovi.Models.EF;

namespace Ferovi.Models.Repositories.Interfaces
{
    public interface IMenusPrincipalesRepository
    {
        Task CreateAsync(MenusPrincipales menu);
        Task DeleteAsync(int id);
        Task<IEnumerable<MenusPrincipales>> GetAllAsync();
        Task<IEnumerable<MenusPrincipales>> GetAllByDatatablesFiltersAsync(int start, int length, string searchValue, string filterName, string filterLink, int filterLevel, string sortColumn, string sortDirection);
        Task<MenusPrincipales> GetByIdAsync(int id);
        Task UpdateAsync(MenusPrincipales menu);
    }
}