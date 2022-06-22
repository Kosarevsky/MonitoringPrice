using System.Linq.Expressions;

namespace MonitoringPrice.Data.Interfaces
{
    /// <summary>
    /// Интерфейс репозиториев
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepositoryEntity<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IQueryable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        void DeleteAsync(int id);
    }
}
