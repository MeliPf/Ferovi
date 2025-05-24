#nullable disable
using Ferovi.Models.EF;
using Ferovi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferovi.Repositories
{
    public class BaseRepository<T>(FeroviContext context) : IBaseRepository<T> where T : class
    {
        private readonly FeroviContext _context = context;

        public IQueryable<T> Consulta()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public Task Create(T entity)
        {
            _context.Set<T>().Add(entity);
            return Task.CompletedTask;
        }

        public Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }
    }
}