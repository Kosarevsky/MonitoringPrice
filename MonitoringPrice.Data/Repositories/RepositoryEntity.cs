using Microsoft.EntityFrameworkCore;
using MonitoringPrice.Data.Entities.Models;
using MonitoringPrice.Data.Interfaces;
using System.Linq.Expressions;

namespace MonitoringPrice.Data.Repositories
{
    public class RepositoryEntity<TEntity> : IRepositoryEntity<TEntity> where TEntity : class
    {
        protected readonly AppDbContext Context;
        private readonly DbSet<TEntity> _dbSet;
        protected RepositoryEntity(AppDbContext context)
        { 
            Context = context;
            _dbSet = Context.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }
        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);

            if (entity == null) return;
            _dbSet.Remove(entity);
            Context.SaveChanges();
        }
    }
}
