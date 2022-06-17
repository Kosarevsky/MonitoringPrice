using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Helpers.Attributes
{
    public class FirstDayToCurrentDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime checkDateTime)
            { 
                var now = DateTime.Now.Date;
                return checkDateTime >= new DateTime(now.Year, now.Month, 1) && checkDateTime <= now;
            }
            return false;
        }
    }
}
