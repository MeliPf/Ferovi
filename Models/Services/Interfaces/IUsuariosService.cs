using Ferovi.Models.VM;

namespace Ferovi.Models.Services.Interfaces
{
    public interface IUsuariosService
    {
        Task AssignRolAUsuarioAsync(int idUsuario, int idRol);
        Task CreateRolAsync(RolesViewModel modelo);
        Task CreateUsuarioAsync(UsuariosViewModel modelo);
        Task DeleteRolAsync(int idRol);
        Task DeleteRolDeUsuarioAsync(int idUsuario, int idRol);
        Task DeleteUsuarioAsync(int idUsuario);
        Task<List<RolesViewModel>> GetAllByDatatablesFilterRolessAsync(int start, int length, string searchValue, string filterUserName, string filterRole, string sortColumn, string sortDirection);
        Task<List<UsuariosViewModel>> GetAllByDatatablesFiltersUsuariosAsync(int start, int length, string searchValue, string filterUserName, string filterRole, string sortColumn, string sortDirection);
        Task<List<RolesViewModel>> GetAllRolesAsync();
        Task<List<UsuariosViewModel>> GetAllUsuariosAsync();
        Task<RolesViewModel> GetRolesByIdAsync(int id);
        Task<UsuariosViewModel> GetUsuariosByIdAsync(int id);
        Task UpdateUsuarioAsync(UsuariosViewModel modelo);
    }
}