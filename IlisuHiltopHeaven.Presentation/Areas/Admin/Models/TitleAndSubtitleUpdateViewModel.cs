using IlisuHiltopHeaven.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Presentation.Areas.Admin.Models
{
    public class TitleAndSubtitleUpdateViewModel
    {
        public Guid? LanguageGroupId { get; set; }
        [DisplayName("İkinci Bölmə Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string TitleAz1 { get; set; }
        [DisplayName("İkinci Bölmə Alt Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string SubtitleAz1 { get; set; }
        [DisplayName("Xidmətlər Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string TitleAz2 { get; set; }
        [DisplayName("Xidmətlər Alt Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string SubtitleAz2 { get; set; }
        [DisplayName("Ekoturizm Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string TitleAz3 { get; set; }
        [DisplayName("Ekoturizm Alt Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string SubtitleAz3 { get; set; }


        [DisplayName("İkinci Bölmə Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string TitleEn1 { get; set; }
        [DisplayName("İkinci Bölmə Alt Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string SubtitleEn1 { get; set; }
        [DisplayName("Xidmətlər Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string TitleEn2 { get; set; }
        [DisplayName("Xidmətlər Alt Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string SubtitleEn2 { get; set; }
        [DisplayName("Ekoturizm Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string TitleEn3 { get; set; }
        [DisplayName("Ekoturizm Alt Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string SubtitleEn3 { get; set; }


        [DisplayName("İkinci Bölmə Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string TitleRu1 { get; set; }
        [DisplayName("İkinci Bölmə Alt Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string SubtitleRu1 { get; set; }
        [DisplayName("Xidmətlər Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string TitleRu2 { get; set; }
        [DisplayName("Xidmətlər Alt Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string SubtitleRu2 { get; set; }
        [DisplayName("Ekoturizm Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string TitleRu3 { get; set; }
        [DisplayName("Ekoturizm Alt Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string SubtitleRu3 { get; set; }

        [DisplayName("Dil")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        public int LanguageId { get; set; }
        public IList<Language> Languages { get; set; }
    }
}
