using IlisuHiltopHeaven.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Presentation.Areas.Admin.Models
{
    public class AdvantageAddViewModel
    {
        [DisplayName("Başlıq")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string Title { get; set; }
        [DisplayName("Dil")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public IList<Language> Languages { get; set; }
    }
}
