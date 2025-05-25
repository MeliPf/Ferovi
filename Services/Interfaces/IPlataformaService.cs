using Ferovi.Models.VM;

namespace Ferovi.Services.Interfaces
{
    public interface IPlataformaService
    {
        Task<IEnumerable<IconosViewModel>> GetAllAsync();
        Task<IEnumerable<MenusPrincipalesViewModel>> GetAllByDatatablesFiltersAsync(int start, int length, string searchValue, string filterName, string filterLink, int filterLevel, string sortColumn, string sortDirection);
        Task<IEnumerable<MenusPrincipalesViewModel>> ObtenerMenuPrincipal();
    }
}