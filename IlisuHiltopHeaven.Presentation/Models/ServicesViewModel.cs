using IlisuHiltopHeaven.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Presentation.Models
{
    public class ServicesViewModel
    {
        public ICollection<Service> Services { get; set; }
        public ICollection<Advantage> Advantages { get; set; }
        public ICollection<AdvantageHilltop> AdvantageHiltops { get; set; }
        public ICollection<Office> Offices { get; set; }
        public HomePage HomePages { get; set; }
        public SocialMedia SocialMedia { get; set; }
        public TitleAndSubtitle TitleAndSubtitle { get; set; }
    }
}
