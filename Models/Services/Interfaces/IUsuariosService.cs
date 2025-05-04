using Ferovi.Models.VM;

namespace Ferovi.Models.Services.Interfaces
{
    public interface IUsuariosService
    {
        Task CreateRolAsync(RolesViewModel rolesViewModel);
        Task CreateUsersAsync(UsuariosViewModel usersViewModel);
        Task CreateUsersRolesAsync(int idUsers, int idRoles);
        Task DeleteRolAsync(int id);
        Task DeleteUsersAsync(int idUsuario);
        Task DeleteUsersRolesAsync(int id);
        Task<List<RolesViewModel>> GetAllByDatatablesFilterRolessAsync(int start, int length, string searchValue, string filterCode, string filterDescription, string sortColumn, string sortDirection);
        Task<List<UsuariosViewModel>> GetAllByDatatablesFiltersUsuariosAsync(int start, int length, string searchValue, string filterUserName, string filterFirstLastName, string filterSecondLastName, string filterAlias, string filterEmail, string sortColumn, string sortDirection);
        Task<List<RolesViewModel>> GetAllRolesAsync();
        Task<List<UsuariosViewModel>> GetAllUsersAsync();
        Task<RolesViewModel> GetRolesByIdAsync(int id);
        Task<UsuariosViewModel> GetUsersByIdAsync(int id);
        Task UpdateUsersAsync(UsuariosViewModel usersViewModel);
    }
}