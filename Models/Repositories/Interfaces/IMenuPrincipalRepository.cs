using Ferovi.Models.EF;

namespace Ferovi.Models.Repositories.Interfaces
{
    public interface IMenuPrincipalRepository
    {
        Task CreateAsync(MenuPrincipal menu);
        Task DeleteAsync(int id);
        Task<IEnumerable<MenuPrincipal>> GetAllAsync();
        Task<MenuPrincipal> GetByIdAsync(int id);
        Task UpdateAsync(MenuPrincipal menu);
    }
}