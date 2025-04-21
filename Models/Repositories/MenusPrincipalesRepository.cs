#nullable disable
using Ferovi.Models.EF;
using Ferovi.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferovi.Models.Repositories
{
    public class MenusPrincipalesRepository(FeroviContext context) : IMenusPrincipalesRepository
    {
        private readonly FeroviContext _context = context;

        public async Task<MenusPrincipales> GetByIdAsync(int id)
        {
            return await _context.MenusPrincipales.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<MenusPrincipales>> GetAllAsync()
        {
            return await _context.MenusPrincipales.ToListAsync();
        }

        public async Task<IEnumerable<MenusPrincipales>> GetAllByDatatablesFiltersAsync(int start, int length, string searchValue, string filterName, string filterLink, int filterLevel, string sortColumn, string sortDirection)
        {
            var query = _context.MenusPrincipales.AsQueryable();

            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(m =>
                    m.Nombre.Contains(searchValue) ||
                    m.Enlace.Contains(searchValue));
            }

            if (!string.IsNullOrEmpty(filterName))
            {
                query = query.Where(m => m.Nombre.Contains(filterName));
            }

            if (!string.IsNullOrEmpty(filterLink))
            {
                query = query.Where(m => m.Enlace.Contains(filterLink));
            }

            if (filterLevel > 0)
            {
                query = query.Where(m => m.Nivel.Equals(filterLevel));
            }

            if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortDirection))
            {
                query = sortColumn switch
                {
                    "Nombre" => sortDirection == "asc"
                        ? query.OrderBy(m => m.Nombre)
                        : query.OrderByDescending(m => m.Nombre),
                    "Enlace" => sortDirection == "asc"
                        ? query.OrderBy(m => m.Enlace)
                        : query.OrderByDescending(m => m.Enlace),
                    "Nivel" => sortDirection == "asc"
                        ? query.OrderBy(m => m.Nivel)
                        : query.OrderByDescending(m => m.Nivel),
                    _ => query
                };
            }

            query = query.Skip(start).Take(length);

            return await query.ToListAsync();
        }

        public async Task CreateAsync(MenusPrincipales menu)
        {
            _context.MenusPrincipales.Add(menu);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MenusPrincipales menu)
        {
            _context.MenusPrincipales.Update(menu);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var menu = await _context.MenusPrincipales.FindAsync(id);
            if (menu != null)
            {
                _context.MenusPrincipales.Remove(menu);
                await _context.SaveChangesAsync();
            }
        }
    }
}