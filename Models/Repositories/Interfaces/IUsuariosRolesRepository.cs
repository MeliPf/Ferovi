using Ferovi.Models.EF;

namespace Ferovi.Models.Repositories.Interfaces
{
    public interface IUsuariosRolesRepository
    {
        Task CreateAsync(Usuarios_Roles menu);
        Task DeleteAsync(int id);
    }
}