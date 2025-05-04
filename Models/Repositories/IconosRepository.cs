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

        public async Task CreateAsync(Iconos icons)
        {
            _context.Iconos.Add(icons);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Iconos icons)
        {
            _context.Iconos.Update(icons);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Iconos icons = await _context.Iconos.FindAsync(id);

            if (icons != null)
            {
                _context.Iconos.Remove(icons);
                await _context.SaveChangesAsync();
            }
        }
    }
}