using IlisuHiltopHeaven.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Presentation.Areas.Admin.Models
{
    public class AdvantageViewModel
    {
        public IList<Advantage> Advantages { get; set; }
        public IList<AdvantageHilltop> AdvantageHilltops { get; set; }
    }
}
