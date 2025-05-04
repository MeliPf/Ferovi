using Ferovi.Models.EF;

namespace Ferovi.Models.Repositories.Interfaces
{
    public interface IRolesRepository
    {
        Task CreateAsync(Roles roles);
        Task DeleteAsync(int id);
        Task<IEnumerable<Roles>> GetAllAsync();
        Task<IEnumerable<Roles>> GetAllByDatatablesFiltersAsync(int start, int length, string searchValue, string filterCode, string filterDescription, string sortColumn, string sortDirection);
        Task<Roles> GetByIdAsync(int id);
        Task UpdateAsync(Roles roles);
    }
}