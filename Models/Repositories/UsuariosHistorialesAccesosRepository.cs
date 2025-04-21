#nullable disable
using Ferovi.Models.EF;
using Microsoft.EntityFrameworkCore;

namespace Ferovi.Models.Repositories
{
    public class UsuariosHistorialesAccesosRepository(FeroviContext context)
    {
        private readonly FeroviContext _context = context;

        public async Task<UsuariosHistorialesAccesos> GetByIdAsync(int id)
        {
            return await _context.UsuariosHistorialesAccesos.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<UsuariosHistorialesAccesos>> GetAllAsync()
        {
            return await _context.UsuariosHistorialesAccesos.ToListAsync();
        }
        public async Task<IEnumerable<UsuariosHistorialesAccesos>> GetAllByDatatablesFiltersAsync() // TODO: configurar con Datatables
        {
            return await _context.UsuariosHistorialesAccesos.ToListAsync();
        }

        public async Task CreateAsync(UsuariosHistorialesAccesos registro)
        {
            _context.UsuariosHistorialesAccesos.Add(registro);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UsuariosHistorialesAccesos registro)
        {
            _context.UsuariosHistorialesAccesos.Update(registro);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var registro = await _context.UsuariosHistorialesAccesos.FindAsync(id);
            if (registro != null)
            {
                _context.UsuariosHistorialesAccesos.Remove(registro);
                await _context.SaveChangesAsync();
            }
        }
    }
}
