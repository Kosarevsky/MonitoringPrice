using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringPrice.WebApi.Interfaces
{
    public interface IUnitOfWork
    {
       // ITextFieldsRepository TextFields { get; }
        //IServiceItemsRepository ServiceItems { get; }
        ICategoryRepository Category { get; }
        ICharacteristicRepository Characteristic { get; }
        IManufacturerRepository Manufacturer { get; }
        IPriceRepository Price { get; }
        IProductRepository Product { get; }
        IRamRepository Ram { get; }
        IUrlRepository Url { get; }
    }
}
