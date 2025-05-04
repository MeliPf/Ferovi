#nullable disable
using Ferovi.Models.EF;
using Ferovi.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferovi.Models.Repositories
{
    public class RolesRepository(FeroviContext context) : IRolesRepository
    {
        private readonly FeroviContext _context = context;

        public async Task<Roles> GetByIdAsync(int id)
        {
            return await _context.Roles.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Roles>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<IEnumerable<Roles>> GetAllByDatatablesFiltersAsync(int start, int length, string searchValue,
                                                                             string filterCode, string filterDescription, string sortColumn,
                                                                             string sortDirection)
        {
            IQueryable<Roles> query = _context.Roles
                .AsQueryable();

            if (!string.IsNullOrEmpty(filterCode))
            {
                query = query.Where(ur => ur.Codigo.Contains(filterCode));
            }

            if (!string.IsNullOrEmpty(filterDescription))
            {
                query = query.Where(ur => ur.Descripcion.Contains(filterDescription));
            }

            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(ur =>
                    ur.Codigo.Contains(searchValue) ||
                    ur.Descripcion.Contains(searchValue));
            }

            if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortDirection))
            {
                query = sortColumn switch
                {
                    "Codigo" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.Codigo)
                        : query.OrderByDescending(ur => ur.Codigo),
                    "Descripcion" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.Descripcion)
                        : query.OrderByDescending(ur => ur.Descripcion),
                    _ => query
                };
            }

            query = query.Skip(start).Take(length);

            return await query.ToListAsync();
        }

        public async Task CreateAsync(Roles roles)
        {
            _context.Roles.Add(roles);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Roles roles)
        {
            _context.Roles.Update(roles);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Roles roles = await _context.Roles.FindAsync(id);

            if (roles != null)
            {
                _context.Roles.Remove(roles);
                await _context.SaveChangesAsync();
            }
        }
    }
}