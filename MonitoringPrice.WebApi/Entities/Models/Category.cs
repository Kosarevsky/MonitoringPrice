using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonitoringPrice.WebApi.Entities.Models
{
    [Table("Category")]
    public class Category
    {
#nullable disable
        /// <summary>Id</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Наименование категории</summary>
        [Required]
        [StringLength(255)]
        //[Column(TypeName = "varchar")]
        public string CategoryName { get; set; }
#nullable enable
    }
}
