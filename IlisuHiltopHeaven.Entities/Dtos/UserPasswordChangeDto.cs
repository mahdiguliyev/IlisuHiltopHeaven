using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IlisuHiltopHeaven.Entities.Dtos
{
    public class UserPasswordChangeDto
    {
        [DisplayName("Mövcud şifrə")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(30, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [DisplayName("Yeni şifrə")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(30, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [DisplayName("Yeni şifrəni təstiqləyin")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(30, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Yeni daxil etdiyiniz şifrələr bir-birinə uyğun deyil.")]
        public string RepeatPassword { get; set; }
    }
}
