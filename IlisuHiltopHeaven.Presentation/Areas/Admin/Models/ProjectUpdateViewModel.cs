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
    public class ProjectUpdateViewModel
    {
        public Guid? LanguageGroupId { get; set; }
        [DisplayName("Lokasiya")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string TitleAz1 { get; set; }
        [DisplayName("Mənzil Layihəsi")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string TitleAz2 { get; set; }

        [DisplayName("Lokasiya")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string TitleEn1 { get; set; }
        [DisplayName("Mənzil Layihəsi")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string TitleEn2 { get; set; }

        [DisplayName("Lokasiya")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string TitleRu1 { get; set; }
        [DisplayName("Mənzil Layihəsi")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string TitleRu2 { get; set; }

        [DisplayName("Əsas Mətn")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string MainPlanAz { get; set; }
        [DisplayName("Lokasiya Alt Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string ComlexLocAz { get; set; }
        [DisplayName("Mənzil Layihəsi Alt Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string BuildingProjectAz { get; set; }

        [DisplayName("Əsas Mətn")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string MainPlanEn { get; set; }
        [DisplayName("Lokasiya Alt Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string ComlexLocEn { get; set; }
        [DisplayName("Mənzil Layihəsi Alt Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string BuildingProjectEn { get; set; }

        [DisplayName("Əsas Mətn")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string MainPlanRu { get; set; }
        [DisplayName("Lokasiya Alt Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string ComlexLocRu { get; set; }
        [DisplayName("Mənzil Layihəsi Alt Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string BuildingProjectRu { get; set; }

        [DisplayName("1-ci Mərtəbə Şəkil 1")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(250, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string MainImageOne { get; set; }
        [DisplayName("Şəkil Dəyiş")]
        public IFormFile MainImageFileOne { get; set; }
        [DisplayName("1-ci Mərtəbə Şəkil 2")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(250, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string MainImageTwo { get; set; }
        [DisplayName("Şəkil Dəyiş")]
        public IFormFile MainImageFileTwo { get; set; }
        [DisplayName("2-ci Mərtəbə Şəkil 1")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(250, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string MainImageThree { get; set; }
        [DisplayName("Şəkil Dəyiş")]
        public IFormFile MainImageFileThree { get; set; }
        [DisplayName("2-ci Mərtəbə Şəkil 2")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(250, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string MainImageFour { get; set; }
        [DisplayName("Şəkil Dəyiş")]
        public IFormFile MainImageFileFour { get; set; }
        [DisplayName("3-ci Mərtəbə Şəkil 1")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(250, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string MainImageFive { get; set; }
        [DisplayName("Şəkil Dəyiş")]
        public IFormFile MainImageFileFive { get; set; }
        [DisplayName("3-ci Mərtəbə Şəkil 2")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(250, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string MainImageSix { get; set; }
        [DisplayName("Şəkil Dəyiş")]
        public IFormFile MainImageFileSix { get; set; }

        [DisplayName("Şəkil 1")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(250, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string ImageOne { get; set; }
        [DisplayName("Şəkil Dəyiş")]
        public IFormFile ImageFileOne { get; set; }
        [DisplayName("Şəkil 2")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(250, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string ImageTwo { get; set; }
        [DisplayName("Şəkil Dəyiş")]
        public IFormFile ImageFileTwo { get; set; }
        [DisplayName("Şəkil 3")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(250, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string ImageThree { get; set; }
        [DisplayName("Şəkil Dəyiş")]
        public IFormFile ImageFileThree { get; set; }
        [DisplayName("Şəkil 4")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(250, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string ImageFour { get; set; }
        [DisplayName("Şəkil Dəyiş")]
        public IFormFile ImageFileFour { get; set; }
        [DisplayName("Şəkil 5")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(250, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string ImageFive { get; set; }
        [DisplayName("Şəkil Dəyiş")]
        public IFormFile ImageFileFive { get; set; }
        [DisplayName("Şəkil 6")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(250, ErrorMessage = "{0} {1} simvol sayını keçməməlidir.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string ImageSix { get; set; }
        [DisplayName("Şəkil Dəyiş")]
        public IFormFile ImageFileSix { get; set; }
        [DisplayName("Map Url")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string MapUrl { get; set; }
        public int LanguageId { get; set; }
        public IList<Language> Languages { get; set; }
    }
}
