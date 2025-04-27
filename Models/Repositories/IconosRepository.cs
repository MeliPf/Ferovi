#nullable disable
using Ferovi.Models.EF;
using Ferovi.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferovi.Models.Repositories
{
    public class IconosRepository(FeroviContext context) : IIconosRepository
    {
        private readonly FeroviContext _context = context;

        public async Task<Iconos> GetByIdAsync(int id)
        {
            return await _context.Iconos.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Iconos>> GetAllAsync()
        {
            return await _context.Iconos.ToListAsync();
        }

        public async Task CreateAsync(Iconos menu)
        {
            _context.Iconos.Add(menu);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Iconos menu)
        {
            _context.Iconos.Update(menu);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var menu = await _context.Iconos.FindAsync(id);
            if (menu != null)
            {
                _context.Iconos.Remove(menu);
                await _context.SaveChangesAsync();
            }
        }
    }
}