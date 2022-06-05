using IlisuHiltopHeaven.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Presentation.Areas.Admin.Models
{
    public class OfficeUpdateViewModel
    {
        public Guid? LanguageGroupId { get; set; }
        [DisplayName("Ofis adı")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(50, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string OfficeNameAz { get; set; }
        [DisplayName("Adres")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(150, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string AddressAz { get; set; }
        [DisplayName("Telefon nömrəsi 1")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        [DataType(DataType.PhoneNumber)]
        public string NumberAz1 { get; set; }
        [DisplayName("Telefon nömrəsi 2")]
        [DataType(DataType.PhoneNumber)]
        public string NumberAz2 { get; set; }
        [DisplayName("Telefon nömrəsi 3")]
        [DataType(DataType.PhoneNumber)]
        public string NumberAz3 { get; set; }
        [DisplayName("E-mail")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(150, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        [DataType(DataType.EmailAddress)]
        public string EmailAz { get; set; }
        [DisplayName("İş günləri")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(50, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string WorkDaysAz { get; set; }
        [DisplayName("İş saatları")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(50, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string WorkHoursAz { get; set; }


        [DisplayName("Ofis adı")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(50, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string OfficeNameEn { get; set; }
        [DisplayName("Adres")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(150, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string AddressEn { get; set; }
        [DisplayName("Telefon nömrəsi 1")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(50, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string NumberEn1 { get; set; }
        [DisplayName("Telefon nömrəsi 2")]
        [DataType(DataType.PhoneNumber)]
        public string NumberEn2 { get; set; }
        [DisplayName("Telefon nömrəsi 3")]
        [DataType(DataType.PhoneNumber)]
        public string NumberEn3 { get; set; }
        [DisplayName("E-mail")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(150, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        [DataType(DataType.EmailAddress)]
        public string EmailEn { get; set; }
        [DisplayName("İş günləri")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(50, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string WorkDaysEn { get; set; }
        [DisplayName("İş saatları")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(50, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string WorkHoursEn { get; set; }


        [DisplayName("Ofis adı")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(50, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string OfficeNameRu { get; set; }
        [DisplayName("Adres")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(150, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string AddressRu { get; set; }
        [DisplayName("Telefon nömrəsi 1")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(50, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string NumberRu1 { get; set; }
        [DisplayName("Telefon nömrəsi 2")]
        [DataType(DataType.PhoneNumber)]
        public string NumberRu2 { get; set; }
        [DisplayName("Telefon nömrəsi 3")]
        [DataType(DataType.PhoneNumber)]
        public string NumberRu3 { get; set; }
        [DisplayName("E-mail")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(150, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        [DataType(DataType.EmailAddress)]
        public string EmailRu { get; set; }
        [DisplayName("İş günləri")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(50, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string WorkDaysRu { get; set; }
        [DisplayName("İş saatları")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(50, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string WorkHoursRu { get; set; }

        [DisplayName("Map Url")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvol sayından az olmamalıdır.")]
        public string MapUrl { get; set; }
        public int LanguageId { get; set; }
        public IList<Language> Languages { get; set; }
    }
}
