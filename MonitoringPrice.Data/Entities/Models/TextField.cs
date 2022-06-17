using System.ComponentModel.DataAnnotations;

namespace MonitoringPrice.Data.Entities.Models
{
#nullable disable
    public class TextField : EntityBase
    {
        [Required]
        public string CodeWord { get; set; }

        [Display(Name = "Название страницы (заголовок)")]
        public override string Title { get; set; } = "Информационная страница";

        [Display(Name = "Содержание страницы")]
        public override string Text { get; set; } = "Содержимое заполняется администратором";
    }
#nullable enable
}
