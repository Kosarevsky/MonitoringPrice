using Microsoft.EntityFrameworkCore;
using MonitoringPrice.WebApi.Entities.Context;
using MonitoringPrice.WebApi.Entities.Models;

namespace MonitoringPrice.WebApi.Interfaces
{
    public class ManufacturerRepository : RepositoryEntity<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<int> SaveAsync(Manufacturer entity)
        {
            if (entity.Id == default)
                Context.Entry(entity).State = EntityState.Added;
            else
                Context.Entry(entity).State = EntityState.Modified;
            return await Context.SaveChangesAsync();
        }
    }
}
