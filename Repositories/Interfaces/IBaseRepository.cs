namespace Ferovi.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> Consulta();
        Task Create(T entity);
        Task Delete(T entity);
        Task<T> GetByIdAsync(int id);
        Task Update(T entity);
    }
}