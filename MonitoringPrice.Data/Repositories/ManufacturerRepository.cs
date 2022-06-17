using MonitoringPrice.Data.Interfaces;
using MonitoringPrice.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace MonitoringPrice.Data.Repositories
{
    public class ManufacturerRepository : RepositoryEntity<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(AppDbContext context) : base(context)
        {
        }

        public void Save(Manufacturer entity)
        {
            if (entity.Id == default)
                Context.Entry(entity).State = EntityState.Added;
            else
                Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
