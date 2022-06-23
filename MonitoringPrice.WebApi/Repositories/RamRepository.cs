using Microsoft.EntityFrameworkCore;
using MonitoringPrice.WebApi.Entities.Context;
using MonitoringPrice.WebApi.Entities.Models;

namespace MonitoringPrice.WebApi.Interfaces
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
