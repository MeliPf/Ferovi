using Ferovi.Models.EF;

namespace Ferovi.Models.Repositories.Interfaces
{
    public interface IIconosRepository
    {
        Task CreateAsync(Iconos menu);
        Task DeleteAsync(int id);
        Task<IEnumerable<Iconos>> GetAllAsync();
        Task<Iconos> GetByIdAsync(int id);
        Task UpdateAsync(Iconos menu);
    }
}