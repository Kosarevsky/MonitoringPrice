using MonitoringPrice.WebApi.Entities.Models;

namespace MonitoringPrice.WebApi.Interfaces
{
    public interface IServiceItemsRepository 
    {
        IQueryable<ServiceItem> GetServiceItems();
        ServiceItem GetServiceItemById(Guid id);
        void SaveServiceItem(ServiceItem entity);
        void DeleteServiceItem(Guid id);
    }
}
