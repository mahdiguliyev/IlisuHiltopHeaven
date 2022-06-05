using IlisuHiltopHeaven.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Presentation.Areas.Admin.Models
{
    public class BannerViewModel
    {
        public ICollection<Banner> Banners { get; set; }
    }
}
