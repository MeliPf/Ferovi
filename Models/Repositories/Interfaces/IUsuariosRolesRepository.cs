using Ferovi.Models.EF;

namespace Ferovi.Models.Repositories.Interfaces
{
    public interface IUsuariosRolesRepository
    {
        Task CreateAsync(Usuarios_Roles usersRoles);
        Task DeleteAsync(int id);
    }
}