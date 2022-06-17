using Microsoft.EntityFrameworkCore;
using MonitoringPrice.Data.Entities.Models;
using MonitoringPrice.Data.Interfaces;

namespace MonitoringPrice.Data.Repositories
{
    public class RamRepository : RepositoryEntity<Ram>, IRamRepository
    {
        public RamRepository(AppDbContext context) : base(context)
        {
        }

        public void Save(Ram entity)
        {
            if (entity.Id == default)
                Context.Entry(entity).State = EntityState.Added;
            else
                Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
