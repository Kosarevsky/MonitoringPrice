using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonitoringPrice.WebApi.Entities.Models
{
    [Table("WebSite")]
    public class WebSite
    {
#nullable disable
        ///<summary> Id записи </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Наименование магазина</summary>
        [StringLength(255)]
        //[Column(TypeName = "varchar")]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
#nullable enable
    }
}
