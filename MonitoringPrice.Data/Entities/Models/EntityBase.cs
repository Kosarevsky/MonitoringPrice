using System.ComponentModel.DataAnnotations;

namespace MonitoringPrice.Data.Entities.Models
{
    public abstract class EntityBase
    {
        protected EntityBase()
        { 
            DateAdded =DateTime.UtcNow;
        }

        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Название (заголовок)")]
        public virtual string Title { get; set; } = string.Empty;

        [Display(Name = "Краткое описание")]
        public virtual string SubTitle { get; set; } = string.Empty;
        
        [Display(Name = "Полное описание")]
        public virtual string Text { get; set; } = string.Empty;
       
        [Display(Name = "Титульная картинка")]
        public virtual string TitleImagePath { get; set; } = string.Empty;
        
        [Display(Name = "SEO Metatag Title")]
        public string MetaTitle { get; set; } = string.Empty;

        [Display(Name = "Seo Metatag Description")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Seo Metatag Keywords")]
        public string Keywords { get; set; } = string.Empty;

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
    }
}
