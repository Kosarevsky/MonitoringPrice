﻿using Microsoft.EntityFrameworkCore;
using MonitoringPrice.WebApi.Entities.Context;
using MonitoringPrice.WebApi.Entities.Models;

namespace MonitoringPrice.WebApi.Interfaces
{
    public class CharacteristicRepository : RepositoryEntity<Characteristic>, ICharacteristicRepository
    {
        public CharacteristicRepository(AppDbContext context) : base(context)
        {
        }

        [Obsolete]
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
