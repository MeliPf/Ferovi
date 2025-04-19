#nullable disable
using Ferovi.Models.EF;
using Ferovi.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferovi.Models.Repositories
{
    public class MenuPrincipalRepository(FeroviContext context) : IMenuPrincipalRepository
    {
        private readonly FeroviContext _context = context;

        public async Task<MenuPrincipal> GetByIdAsync(int id)
        {
            return await _context.MenuPrincipal.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<MenuPrincipal>> GetAllAsync()
        {
            return await _context.MenuPrincipal.ToListAsync();
        }

        public async Task CreateAsync(MenuPrincipal menu)
        {
            _context.MenuPrincipal.Add(menu);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MenuPrincipal menu)
        {
            _context.MenuPrincipal.Update(menu);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var menu = await _context.MenuPrincipal.FindAsync(id);
            if (menu != null)
            {
                _context.MenuPrincipal.Remove(menu);
                await _context.SaveChangesAsync();
            }
        }
    }
}