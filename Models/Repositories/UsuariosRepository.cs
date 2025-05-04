#nullable disable
using Ferovi.Models.EF;
using Ferovi.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferovi.Models.Repositories
{
    public class UsuariosRepository(FeroviContext context) : IUsuariosRepository
    {
        private readonly FeroviContext _context = context;

        public async Task<Usuarios> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Usuarios>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<IEnumerable<Usuarios>> GetAllByDatatablesFiltersAsync(int start, int length, string searchValue,
                                                                                string filterUserName, string filterFirstLastName, string filterSecondLastName,
                                                                                string filterAlias, string filterEmail, string sortColumn, string sortDirection)
        {
            IQueryable<Usuarios> query = _context.Usuarios
                .AsQueryable();

            if (!string.IsNullOrEmpty(filterUserName))
            {
                query = query.Where(ur => ur.Nombre.Contains(filterUserName));
            }

            if (!string.IsNullOrEmpty(filterFirstLastName))
            {
                query = query.Where(ur => ur.PrimerApellido.Contains(filterFirstLastName));
            }

            if (!string.IsNullOrEmpty(filterSecondLastName))
            {
                query = query.Where(ur => ur.SegundoApellido.Contains(filterSecondLastName));
            }

            if (!string.IsNullOrEmpty(filterAlias))
            {
                query = query.Where(ur => ur.Alias.Contains(filterAlias));
            }

            if (!string.IsNullOrEmpty(filterEmail))
            {
                query = query.Where(ur => ur.Email.Contains(filterEmail));
            }

            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(ur =>
                    ur.Nombre.Contains(searchValue) ||
                    ur.PrimerApellido.Contains(searchValue) ||
                    ur.SegundoApellido.Contains(searchValue) ||
                    ur.Email.Contains(searchValue) ||
                    ur.Alias.Contains(searchValue));
            }

            if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortDirection))
            {
                query = sortColumn switch
                {
                    "Nombre" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.Nombre)
                        : query.OrderByDescending(ur => ur.Nombre),
                    "PrimerApellido" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.PrimerApellido)
                        : query.OrderByDescending(ur => ur.PrimerApellido),
                    "SegundoApellido" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.SegundoApellido)
                        : query.OrderByDescending(ur => ur.SegundoApellido),
                    "Email" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.Email)
                        : query.OrderByDescending(ur => ur.Email),
                    "Alias" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.Alias)
                        : query.OrderByDescending(ur => ur.Alias),
                    _ => query
                };
            }

            query = query.Skip(start).Take(length);

            return await query.ToListAsync();
        }

        public async Task CreateAsync(Usuarios users)
        {
            _context.Usuarios.Add(users);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuarios users)
        {
            _context.Usuarios.Update(users);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Usuarios users = await _context.Usuarios.FindAsync(id);

            if (users != null)
            {
                _context.Usuarios.Remove(users);
                await _context.SaveChangesAsync();
            }
        }
    }
}