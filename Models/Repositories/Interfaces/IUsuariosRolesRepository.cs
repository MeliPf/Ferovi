using Ferovi.Models.EF;

namespace Ferovi.Models.Repositories.Interfaces
{
    public interface IUsuariosRolesRepository
    {
        Task CreateAsync(Usuarios_Roles menu);
        Task DeleteAsync(int id);
        Task<IEnumerable<Usuarios_Roles>> GetAllAsync();
        Task<IEnumerable<Usuarios_Roles>> GetAllByDatatablesFiltersAsync(int start, int length, string searchValue, string filterUserName, string filterRole, string sortColumn, string sortDirection);
        Task<Usuarios_Roles> GetByIdAsync(int id);
        Task UpdateAsync(Usuarios_Roles menu);
    }
}