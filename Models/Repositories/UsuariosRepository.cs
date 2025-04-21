#nullable disable
using Ferovi.Models.EF;
using Microsoft.EntityFrameworkCore;

namespace Ferovi.Models.Repositories
{
    public class UsuariosRepository(FeroviContext context)
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

        public async Task<IEnumerable<Usuarios>> GetAllByDatatablesFiltersAsync() // TODO: configurar con Datatables
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task CreateAsync(Usuarios menu)
        {
            _context.Usuarios.Add(menu);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuarios menu)
        {
            _context.Usuarios.Update(menu);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var menu = await _context.Usuarios.FindAsync(id);
            if (menu != null)
            {
                _context.Usuarios.Remove(menu);
                await _context.SaveChangesAsync();
            }
        }
    }
}