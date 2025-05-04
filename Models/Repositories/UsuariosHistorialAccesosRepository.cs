#nullable disable
using Ferovi.Models.EF;
using Ferovi.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferovi.Models.Repositories
{
    public class UsuariosHistorialAccesosRepository(FeroviContext context) : IUsuariosHistorialAccesosRepository
    {
        private readonly FeroviContext _context = context;

        public async Task<UsuariosHistorialAccesos> GetByIdAsync(int id)
        {
            return await _context.UsuariosHistorialAccesos.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<UsuariosHistorialAccesos>> GetAllAsync()
        {
            return await _context.UsuariosHistorialAccesos.ToListAsync();
        }

        public async Task<IEnumerable<UsuariosHistorialAccesos>> GetAllByDatatablesFiltersAsync(int start, int length, string searchValue,
                                                                                                string filterUserName, string filterFirstLastName, string filterSecondLastName,
                                                                                                string filterAlias, DateTime? filterDate, string sortColumn,
                                                                                                string sortDirection)
        {
            IQueryable<UsuariosHistorialAccesos> query = _context.UsuariosHistorialAccesos
                .AsQueryable();

            if (!string.IsNullOrEmpty(filterUserName))
            {
                query = query.Where(ur => ur.IdUsuarioNavigation.Nombre.Contains(filterUserName));
            }

            if (!string.IsNullOrEmpty(filterFirstLastName))
            {
                query = query.Where(ur => ur.IdUsuarioNavigation.PrimerApellido.Contains(filterFirstLastName));
            }

            if (!string.IsNullOrEmpty(filterSecondLastName))
            {
                query = query.Where(ur => ur.IdUsuarioNavigation.SegundoApellido.Contains(filterSecondLastName));
            }

            if (!string.IsNullOrEmpty(filterAlias))
            {
                query = query.Where(ur => ur.IdUsuarioNavigation.Alias.Contains(filterAlias));
            }

            if (filterDate != null)
            {
                query = query.Where(ur => ur.FechaUltimoAcceso == filterDate); // TODO: verificar que no se compare los segundos.
            }

            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(ur =>
                    ur.IdUsuarioNavigation.Nombre.Contains(searchValue) ||
                    ur.IdUsuarioNavigation.PrimerApellido.Contains(searchValue) ||
                    ur.IdUsuarioNavigation.SegundoApellido.Contains(searchValue) ||
                    ur.IdUsuarioNavigation.Email.Contains(searchValue) ||
                    ur.IdUsuarioNavigation.Alias.Contains(searchValue));
            }

            if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortDirection))
            {
                query = sortColumn switch
                {
                    "Nombre" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.IdUsuarioNavigation.Nombre)
                        : query.OrderByDescending(ur => ur.IdUsuarioNavigation.Nombre),
                    "PrimerApellido" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.IdUsuarioNavigation.PrimerApellido)
                        : query.OrderByDescending(ur => ur.IdUsuarioNavigation.PrimerApellido),
                    "SegundoApellido" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.IdUsuarioNavigation.SegundoApellido)
                        : query.OrderByDescending(ur => ur.IdUsuarioNavigation.SegundoApellido),
                    "Email" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.IdUsuarioNavigation.Email)
                        : query.OrderByDescending(ur => ur.IdUsuarioNavigation.Email),
                    "Alias" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.IdUsuarioNavigation.Alias)
                        : query.OrderByDescending(ur => ur.IdUsuarioNavigation.Alias),
                    "FechaUltimoAcceso" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.FechaUltimoAcceso)
                        : query.OrderByDescending(ur => ur.FechaUltimoAcceso),
                    _ => query
                };
            }

            query = query.Skip(start).Take(length);

            return await query.ToListAsync();
        }

        public async Task CreateAsync(UsuariosHistorialAccesos usersAccessHistory)
        {
            _context.UsuariosHistorialAccesos.Add(usersAccessHistory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UsuariosHistorialAccesos usersAccessHistory)
        {
            _context.UsuariosHistorialAccesos.Update(usersAccessHistory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            UsuariosHistorialAccesos usersAccessHistory = await _context.UsuariosHistorialAccesos.FindAsync(id);

            if (usersAccessHistory != null)
            {
                _context.UsuariosHistorialAccesos.Remove(usersAccessHistory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
