using MonitoringPrice.Data.Interfaces;
using MonitoringPrice.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace MonitoringPrice.Data.Repositories
{
    public class PriceRepository : RepositoryEntity<Price>, IPriceRepository
    {
        public PriceRepository(AppDbContext context) : base(context)
        {
        }

        public void Save(Price entity)
        {
            if (entity.Id == default)
                Context.Entry(entity).State = EntityState.Added;
            else
                Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
