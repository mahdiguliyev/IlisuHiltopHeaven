using IlisuHiltopHeaven.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Presentation.Areas.Admin.Models
{
    public class SellConditionUpdateViewModel
    {
        public Guid? LanguageGroupId { get; set; }
        [DisplayName("Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string TitleAz { get; set; }
        [DisplayName("Açıqlama")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string DescriptionAz { get; set; }

        [DisplayName("Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string TitleEn { get; set; }
        [DisplayName("Açıqlama")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string DescriptionEn { get; set; }

        [DisplayName("Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string TitleRu { get; set; }
        [DisplayName("Açıqlama")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string DescriptionRu { get; set; }

        public int LanguageId { get; set; }
        public IList<Language> Languages { get; set; }
    }
}
