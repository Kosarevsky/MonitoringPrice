using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonitoringPrice.Data.Entities.Models
{
    public class Price
    {
        /// <summary>ID </summary>
        public int Id { get; set; }

        [Required]
        [ForeignKey("Characteristics")]
        public int CharacteristicId { get; set; }

        public Characteristic Characteristics { get; set; }

        /// <summary>Наименование характеристики (цвет)</summary>
        public decimal Cost { get; set; }
    }
}
