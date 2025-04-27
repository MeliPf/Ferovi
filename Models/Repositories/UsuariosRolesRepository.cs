#nullable disable
using Ferovi.Models.EF;
using Ferovi.Models.Repositories.Interfaces;

namespace Ferovi.Models.Repositories
{
    public class UsuariosRolesRepository(FeroviContext context) : IUsuariosRolesRepository
    {
        private readonly FeroviContext _context = context;

        public async Task CreateAsync(Usuarios_Roles menu)
        {
            _context.Usuarios_Roles.Add(menu);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var menu = await _context.Usuarios_Roles.FindAsync(id);
            if (menu != null)
            {
                _context.Usuarios_Roles.Remove(menu);
                await _context.SaveChangesAsync();
            }
        }
    }
}