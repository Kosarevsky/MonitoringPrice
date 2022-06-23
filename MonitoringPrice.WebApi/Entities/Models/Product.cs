using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonitoringPrice.WebApi.Entities.Models
{
#nullable disable
    /// <summary>Сущность - Товар </summary>
    [Table("Product")]

    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }

        /// <summary>Id Производителя</summary>
        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }

        /// <summary>Производитель</summary>
        public Manufacturer Manufacturer { get; set; }

        /// <summary>Id Категории</summary>
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Ram> RamItems { get; set; }
#nullable enable 
    }
}
