using System.Linq.Expressions;

namespace MonitoringPrice.Data.Interfaces
{
    /// <summary>
    /// Интерфейс репозиториев
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepositoryEntity<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Delete(int id);
    }
}
