using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Helpers.Attributes
{
    public class PaymentTypeAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is string myString)
            {
                return
                    myString.Equals("Cash") ||
                    myString.Equals("Check") ||
                    myString.Equals("Credit Card");
            }
            return false;
        }
    }
}
