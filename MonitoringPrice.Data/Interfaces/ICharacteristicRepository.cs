using MonitoringPrice.Data.Entities.Models;

namespace MonitoringPrice.Data.Interfaces
{
    public interface ICharacteristicRepository : IRepositoryEntity<Characteristic>
    {
        void Save(Characteristic entity);
    }
}
