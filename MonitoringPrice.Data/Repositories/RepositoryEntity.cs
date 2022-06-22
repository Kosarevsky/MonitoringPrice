using Microsoft.EntityFrameworkCore;
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

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            var query = await _dbSet.ToListAsync();
            return query.AsQueryable();
        }

        public async Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var query = await _dbSet.Where(predicate).ToListAsync();
            return query.AsQueryable();
        }

        public async Task<IQueryable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var query = await _dbSet.Where(predicate).ToListAsync();
            return query.AsQueryable();
        }
        public async void DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity == null) return;
            _dbSet.Remove(entity);
            await Context.SaveChangesAsync();
        }


    }
}
