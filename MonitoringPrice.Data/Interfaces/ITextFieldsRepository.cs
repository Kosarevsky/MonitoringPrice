using MonitoringPrice.Data.Entities.Models;

namespace MonitoringPrice.Data.Interfaces
//namespace MonitoringPrice.Data.Entities.Models
{
    public interface ITextFieldsRepository
    {
        IQueryable<TextField> GetTextFields();
        TextField GetTextFieldById(Guid id);
        TextField GetTextFieldByCodeWord(string codeWord);
        void SaveTextField(TextField entity);
        void DeleteTextField(Guid id);
    }
}
