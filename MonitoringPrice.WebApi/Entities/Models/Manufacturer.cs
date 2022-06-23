using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonitoringPrice.WebApi.Entities.Models
{
    /// <summary> Сущность Производитель </summary>
    [Table("Manufacturer")]
    public class Manufacturer
    {
        /// <summary> Id </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>Наименование производителя </summary>
        [Required]
        [StringLength(255)]
        //[Column(TypeName = "varchar")]
        public string ManufacturerName { get; set; }
    }
}
