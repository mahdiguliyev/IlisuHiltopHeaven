using IlisuHiltopHeaven.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Presentation.Models
{
    public class ToureViewModel
    {
        public ICollection<Travel> Travels { get; set; }
        public ICollection<Office> Offices { get; set; }
        public HomePage HomePages { get; set; }
        public SocialMedia SocialMedia { get; set; }
    }
}
