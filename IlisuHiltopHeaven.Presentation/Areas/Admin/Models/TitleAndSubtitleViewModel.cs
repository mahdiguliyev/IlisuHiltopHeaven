using IlisuHiltopHeaven.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Presentation.Areas.Admin.Models
{
    public class TitleAndSubtitleViewModel
    {
        public ICollection<TitleAndSubtitle> TitleAndSubtitles { get; set; }
    }
}
