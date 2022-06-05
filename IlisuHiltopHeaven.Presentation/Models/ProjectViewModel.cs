using IlisuHiltopHeaven.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Presentation.Models
{
    public class ProjectViewModel
    {
        public ICollection<Project> Projects { get; set; }
        public ICollection<Office> Offices { get; set; }
        public HomePage HomePages { get; set; }
        public SocialMedia SocialMedia { get; set; }
    }
}
