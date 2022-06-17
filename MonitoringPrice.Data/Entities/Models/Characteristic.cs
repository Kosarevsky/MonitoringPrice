using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonitoringPrice.Data.Entities.Models
{
    public class Characteristic
    {
#nullable disable
        /// <summary>ID </summary>
        public int Id { get; set; }

        /// <summary>Id шапки ссылки url</summary>
        [Required]
        [ForeignKey("Urls")]
        public int UrlId { get; set; }

        public Url Urls { get; set; }
        
        /// <summary>Наименование характеристики (цвет)</summary>
        public string CharacteristicName { get; set; }

        public ICollection<Price> Prices { get; set; }
#nullable enable
    }
}
