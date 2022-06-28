using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonitoringPrice.WebApi.Entities.Models
{
    [Table("Users")]
    public class User
    {
#nullable disable
        [Key]
        [Required]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [ForeignKey("Role")]
        public int? RoleId { get; set; }
        public Role Role { get; set; }
#nullable enable
    }
}
