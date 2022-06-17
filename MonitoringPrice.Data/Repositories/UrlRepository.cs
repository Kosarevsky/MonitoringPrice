using Microsoft.EntityFrameworkCore;
using MonitoringPrice.Data.Entities.Models;
using MonitoringPrice.Data.Interfaces;

namespace MonitoringPrice.Data.Repositories
{
    public class UrlRepository : RepositoryEntity<Url>, IUrlRepository
    {
        public UrlRepository(AppDbContext context) : base(context)
        {
        }

        public void Save(Url entity)
        {
            if (entity.Id == default)
                Context.Entry(entity).State = EntityState.Added;
            else
                Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
