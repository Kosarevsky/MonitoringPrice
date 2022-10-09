using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MonitoringPrice.WebApi.Entities.Models
{
    public class User :IdentityUser
    {
        public int Year { get; set; }
    }
}
