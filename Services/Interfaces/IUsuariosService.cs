using Ferovi.Models.VM;

namespace Ferovi.Services.Interfaces
{
    public interface IUsuariosService
    {
        Task<IEnumerable<RolesViewModel>> GetAllByDatatablesFiltersAsync(int start, int length, string searchValue, string filterCode, string filterDescription, string sortColumn, string sortDirection);
        Task<IEnumerable<UsuariosHistorialAccesosViewModel>> GetAllByDatatablesFiltersAsync(int start, int length, string searchValue, string filterUserName, string filterFirstLastName, string filterSecondLastName, string filterAlias, DateTime? filterDate, string sortColumn, string sortDirection);
        Task<IEnumerable<UsuariosViewModel>> GetAllByDatatablesFiltersAsync(int start, int length, string searchValue, string filterUserName, string filterFirstLastName, string filterSecondLastName, string filterAlias, string filterEmail, string sortColumn, string sortDirection);
    }
}