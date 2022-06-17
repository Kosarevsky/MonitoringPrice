using MonitoringPrice.Data.Interfaces;
using MonitoringPrice.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace MonitoringPrice.Data.Repositories
{
    public class CharacteristicRepository : RepositoryEntity<Characteristic>, ICharacteristicRepository
    {
        public CharacteristicRepository(AppDbContext context) : base(context)
        {
        }

        public void Save(Characteristic entity)
        {
            if (entity.Id == default)
                Context.Entry(entity).State = EntityState.Added;
            else
                Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
