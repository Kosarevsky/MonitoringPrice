using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonitoringPrice.Data.Entities.Models
{
#nullable disable
    [Table("Ram")]
    public class Ram
    {
        /// <summary>ID </summary>
        [Required]
        [Key]
        public int Id { get; set; }

        /// <summary>ID Товара</summary>
        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        /// <summary>Товар</summary>
        public Product Product { get; set; }

        [StringLength(255)]
        public string RamName { get; set; }

        public ICollection<Url> Urls { get; set; }
#nullable enable
    }
}
