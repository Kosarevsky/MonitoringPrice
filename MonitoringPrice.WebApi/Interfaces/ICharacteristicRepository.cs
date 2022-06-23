using MonitoringPrice.WebApi.Entities.Models;

namespace MonitoringPrice.WebApi.Interfaces
{
    public interface ICharacteristicRepository : IRepositoryEntity<Characteristic>
    {
        void Save(Characteristic entity);
    }
}
