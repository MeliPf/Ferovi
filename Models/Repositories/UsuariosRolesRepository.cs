#nullable disable
using Ferovi.Models.EF;
using Ferovi.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferovi.Models.Repositories
{
    public class UsuariosRolesRepository(FeroviContext context) : IUsuariosRolesRepository
    {
        private readonly FeroviContext _context = context;

        public async Task<Usuarios_Roles> GetByIdAsync(int id)
        {
            return await _context.Usuarios_Roles.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Usuarios_Roles>> GetAllAsync()
        {
            return await _context.Usuarios_Roles.ToListAsync();
        }

        public async Task<IEnumerable<Usuarios_Roles>> GetAllByDatatablesFiltersAsync(int start, int length, string searchValue, string filterUserName, string filterRole, string sortColumn, string sortDirection)
        {
            var query = _context.Usuarios_Roles
                .Include(ur => ur.IdUsuarioNavigation)
                .Include(ur => ur.IdRolNavigation)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filterUserName))
            {
                query = query.Where(ur => ur.IdUsuarioNavigation.Nombre.Contains(filterUserName));
            }

            if (!string.IsNullOrEmpty(filterRole))
            {
                query = query.Where(ur => ur.IdRolNavigation.Codigo.Contains(filterRole));
            }

            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(ur =>
                    ur.IdUsuarioNavigation.Nombre.Contains(searchValue) ||
                    ur.IdUsuarioNavigation.PrimerApellido.Contains(searchValue) ||
                    ur.IdUsuarioNavigation.SegundoApellido.Contains(searchValue) ||
                    ur.IdUsuarioNavigation.Email.Contains(searchValue) ||
                    ur.IdRolNavigation.Codigo.Contains(searchValue) ||
                    ur.IdRolNavigation.Descripcion.Contains(searchValue));
            }

            if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortDirection))
            {
                query = sortColumn switch
                {
                    "IdUsuario" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.IdUsuario)
                        : query.OrderByDescending(ur => ur.IdUsuario),
                    "IdRol" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.IdRol)
                        : query.OrderByDescending(ur => ur.IdRol),
                    "UsuarioNombre" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.IdUsuarioNavigation.Nombre)
                        : query.OrderByDescending(ur => ur.IdUsuarioNavigation.Nombre),
                    "RolCodigo" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.IdRolNavigation.Codigo)
                        : query.OrderByDescending(ur => ur.IdRolNavigation.Codigo),
                    _ => query
                };
            }

            query = query.Skip(start).Take(length);

            return await query.ToListAsync();
        }

        public async Task CreateAsync(Usuarios_Roles menu)
        {
            _context.Usuarios_Roles.Add(menu);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuarios_Roles menu)
        {
            _context.Usuarios_Roles.Update(menu);
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