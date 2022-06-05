using IlisuHiltopHeaven.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Presentation.Areas.Admin.Models
{
    public class ServiceUpdateViewModel
    {
        public int Id { get; set; }
        [DisplayName("Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string Title { get; set; }
        [DisplayName("Açıqlama")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string Description { get; set; }
        [DisplayName("Mülkiyyətçi(%)")]
        public int PercentageOwner { get; set; }
        [DisplayName("İlisu Hiltop Heaven(%)")]
        public int PercentageIHH { get; set; }
        [DisplayName("Şəkil")]
        public string Image { get; set; }
        [DisplayName("Dil")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        public int LanguageId { get; set; }
        public IList<Language> Languages { get; set; }
        public List<SelectListItem> Advantages { get; set; }
        public List<SelectListItem> HiltopAdvantages { get; set; }
        [DisplayName("Mülkiyyətçi")]
        public int[] SelectedAdvantages { get; set; }
        [DisplayName("İlisi Hiltop Heaven")]
        public int[] SelectedHiltopAdvantages { get; set; }
    }
}
