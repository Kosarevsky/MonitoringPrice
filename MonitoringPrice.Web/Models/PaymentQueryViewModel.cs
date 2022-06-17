using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.Helpers.Attributes;

namespace MonitoringPrice.Web.Models
{
    public class PaymentQueryViewModel
    {
        [Range(1,int.MaxValue, ErrorMessage = "Значение должно быть в диапазоне от {1} до {2}")]
        [Display(Name = "Id >0")]
        public int PaymentId { get; set; } // больше 0
        [Range(1,100000, ErrorMessage = "Значение должно быть в диапазоне от 1 до 100000")]
        public decimal Amount { get; set; } // больше 0, не больше 100000
        
        [FirstDayToCurrentDate(ErrorMessage = "Дата должна быть в диапазоне ")]
        [Display(Name = "c 1 числа тек месяца по тек число")]

        public DateTime PaymentDate { get; set; } // c 1 числа тек месяца по тек число
        
        [PaymentType]
        public string PaymentType { get; set; } //Cash, Check, Credit Card
    }
}
