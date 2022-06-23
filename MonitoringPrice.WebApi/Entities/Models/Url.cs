using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonitoringPrice.WebApi.Entities.Models
{
    [Table("Url")]
    public class Url
    {
#nullable disable
        /// <summary>ID </summary>
        [Required]
        [Key]
        public int Id { get; set; }

        /// <summary>Id главной записи</summary>
        [Required]
        [ForeignKey("Ram")]
        public int RamId { get; set; }

        public Ram Ram { get; set; }

        /// <summary>Ссылка на алик</summary>
        [Required]
        [StringLength(255)]
        public string Link { get; set; }

        /// <summary>Наименование магазина</summary>
        [StringLength(255)]
        public string ShopName { get; set; }

        /// <summary>Количество заказов</summary>
        public int Orders { get; set; }

        public ICollection<Characteristic> Characteristics { get; set; }
#nullable enable

    }
}
