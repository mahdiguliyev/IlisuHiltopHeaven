using IlisuHiltopHeaven.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Presentation.Areas.Admin.Models
{
    public class ConditionOfPurchasingUpdateViewModel
    {
        public Guid? LanguageGroupId { get; set; }
        [DisplayName("Əsas Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string MainTitleAz { get; set; }
        [DisplayName("Başlıq 1")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string TitleAz1 { get; set; }
        [DisplayName("Açıqlama 1")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string DescriptionAz1 { get; set; }
        [DisplayName("Başlıq 2")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string TitleAz2 { get; set; }
        [DisplayName("Açıqlama 2")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string DescriptionAz2 { get; set; }
        [DisplayName("Başlıq 3")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string TitleAz3 { get; set; }
        [DisplayName("Açıqlama 3")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string DescriptionAz3 { get; set; }


        [DisplayName("Əsas Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string MainTitleEn { get; set; }
        [DisplayName("Başlıq 1")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string TitleEn1 { get; set; }
        [DisplayName("Açıqlama 1")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string DescriptionEn1 { get; set; }
        [DisplayName("Başlıq 2")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string TitleEn2 { get; set; }
        [DisplayName("Açıqlama 2")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string DescriptionEn2 { get; set; }
        [DisplayName("Başlıq 3")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string TitleEn3 { get; set; }
        [DisplayName("Açıqlama 3")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string DescriptionEn3 { get; set; }


        [DisplayName("Əsas Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string MainTitleRu { get; set; }
        [DisplayName("Başlıq 1")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string TitleRu1 { get; set; }
        [DisplayName("Açıqlama 1")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string DescriptionRu1 { get; set; }
        [DisplayName("Başlıq 2")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string TitleRu2 { get; set; }
        [DisplayName("Açıqlama 2")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string DescriptionRu2 { get; set; }
        [DisplayName("Başlıq 3")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string TitleRu3 { get; set; }
        [DisplayName("Açıqlama 3")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string DescriptionRu3 { get; set; }


        [DisplayName("Şəkil")]
        public string Image { get; set; }
        [DisplayName("Şəkil 2")]
        public string Image2 { get; set; }
        [DisplayName("Şəkil 3")]
        public string Image3 { get; set; }
        [DisplayName("Dil")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        public int LanguageId { get; set; }
        public IList<Language> Languages { get; set; }
    }
}
