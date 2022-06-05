using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Presentation.Areas.Admin.Models
{
    public class SocialMediaUpdateViewModel
    {
        public int Id { get; set; }
        [DisplayName("Mobil Nömrə")]
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(50, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        public string PhoneNumber { get; set; }
        [DisplayName("Whatsapp Url")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string WhatsappUrl { get; set; }
        [DisplayName("Instagram Url")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string InstagramUrl { get; set; }
        [Required(ErrorMessage = "{0} tələb olunur.")]
        [MaxLength(500, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string FacebookUrl { get; set; }
        [DisplayName("Youtube Url")]
        [MaxLength(100, ErrorMessage = "{0} {1} simvol sayından artıq olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} {1} simvoldan aşağı olmamalıdır.")]
        public string YoutubeUrl { get; set; }
    }
}
