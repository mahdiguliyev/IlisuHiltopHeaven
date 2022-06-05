using IlisuHiltopHeaven.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IlisuHiltopHeaven.Presentation.Areas.Admin.Models
{
    public class HomePageUpdateViewModel
    {
        public Guid? LanguageGroupId { get; set; }
        [DisplayName("Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string TitleAz { get; set; }
        [DisplayName("Alt Başlıq")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        public string DescriptionAz { get; set; }

        [DisplayName("Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string TitleEn { get; set; }
        [DisplayName("Alt Başlıq")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        public string DescriptionEn { get; set; }

        [DisplayName("Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string TitleRu { get; set; }
        [DisplayName("Alt Başlıq")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        public string DescriptionRu { get; set; }

        [DisplayName("Şəkil")]
        [MaxLength(250, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        public string Image { get; set; }
        [DisplayName("Şəkil Əlavə Et")]
        public IFormFile ImageFile { get; set; }
        public int LanguageId { get; set; }
        public IList<Language> Languages { get; set; }
        public string PageName { get; set; }
    }
}
