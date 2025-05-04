#nullable disable
using Ferovi.Models.EF;
using Ferovi.Models.Repositories.Interfaces;

namespace Ferovi.Models.Repositories
{
    public class UsuariosRolesRepository(FeroviContext context) : IUsuariosRolesRepository
    {
        private readonly FeroviContext _context = context;

        public async Task CreateAsync(Usuarios_Roles usersRoles)
        {
            _context.Usuarios_Roles.Add(usersRoles);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Usuarios_Roles usersRoles = await _context.Usuarios_Roles.FindAsync(id);

            if (usersRoles != null)
            {
                _context.Usuarios_Roles.Remove(usersRoles);
                await _context.SaveChangesAsync();
            }
        }
    }
}