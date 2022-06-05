using IlisuHiltopHeaven.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Presentation.Areas.Admin.Models
{
    public class HousingProjectUpdateViewModel
    {
        public Guid? LanguageGroupId { get; set; }
        [DisplayName("Əsas Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(150, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string MainTitleAz { get; set; }
        [DisplayName("Açıqlama")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string DescriptionAz { get; set; }
        [DisplayName("1-ci Mərtəbə")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string floorAz1 { get; set; }
        [DisplayName("2-ci Mərtəbə")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string floorAz2 { get; set; }
        [DisplayName("3-ci Mərtəbə")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string floorAz3 { get; set; }


        [DisplayName("Əsas Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(150, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string MainTitleEn { get; set; }
        [DisplayName("Açıqlama")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string DescriptionEn { get; set; }
        [DisplayName("1-ci Mərtəbə")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string floorEn1 { get; set; }
        [DisplayName("2-ci Mərtəbə")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string floorEn2 { get; set; }
        [DisplayName("3-ci Mərtəbə")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string floorEn3 { get; set; }


        [DisplayName("Əsas Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(150, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string MainTitleRu { get; set; }
        [DisplayName("Açıqlama")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string DescriptionRu { get; set; }
        [DisplayName("1-ci Mərtəbə")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string floorRu1 { get; set; }
        [DisplayName("2-ci Mərtəbə")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string floorRu2 { get; set; }
        [DisplayName("3-ci Mərtəbə")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string floorRu3 { get; set; }


        [DisplayName("Şəkil 1")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(250, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string Image1 { get; set; }
        [DisplayName("Şəkil Əlavə Et 1")]
        public IFormFile ImageFileOne { get; set; }
        [DisplayName("Şəkil 2")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(250, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string Image2 { get; set; }
        [DisplayName("Şəkil Əlavə Et 2")]
        public IFormFile ImageFileTwo { get; set; }
        [DisplayName("Şəkil 3")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(250, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string Image3 { get; set; }
        [DisplayName("Şəkil Əlavə Et 3")]
        public IFormFile ImageFileThree { get; set; }
        [DisplayName("Dil")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        public int LanguageId { get; set; }
        public IList<Language> Languages { get; set; }
    }
}
