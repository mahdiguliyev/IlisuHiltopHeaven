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
    public class TravelUpdateViewModel
    {
        public Guid? LanguageGroupId { get; set; }
        [DisplayName("Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string TitleAz { get; set; }
        [DisplayName("Açıqlama")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string DescriptionAz { get; set; }

        [DisplayName("Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string TitleEn { get; set; }
        [DisplayName("Açıqlama")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string DescriptionEn { get; set; }

        [DisplayName("Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string TitleRu { get; set; }
        [DisplayName("Açıqlama")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string DescriptionRu { get; set; }



        [DisplayName("Şəkil 1")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(250, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string ImageOne { get; set; }
        [DisplayName("Şəkil Əlavə Et 1")]
        public IFormFile ImageFileOne { get; set; }
        [DisplayName("Şəkil 2")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(250, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string ImageTwo { get; set; }
        [DisplayName("Şəkil Əlavə Et 2")]
        public IFormFile ImageFileTwo { get; set; }
        [DisplayName("Şəkil 3")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(250, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string ImageThree { get; set; }
        [DisplayName("Şəkil Əlavə Et 3")]
        public IFormFile ImageFileThree { get; set; }
        [DisplayName("Şəkil 4")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(250, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string ImageFour { get; set; }
        [DisplayName("Şəkil Əlavə Et 4")]
        public IFormFile ImageFileFour { get; set; }
        [DisplayName("Şəkil 5")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(250, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string ImageFive { get; set; }
        [DisplayName("Şəkil Əlavə Et 5")]
        public IFormFile ImageFileFive { get; set; }
        [DisplayName("Şəkil 6")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(250, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string ImageSix { get; set; }
        [DisplayName("Şəkil Əlavə Et 6")]
        public IFormFile ImageFileSix { get; set; }
        public int LanguageId { get; set; }
        public IList<Language> Languages { get; set; }
    }
}
