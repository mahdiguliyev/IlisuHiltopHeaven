using IlisuHiltopHeaven.Entities.Concrete;
using IlisuHiltopHeaven.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Presentation.Models
{
    public class HomePageViewModel
    {
        public ICollection<HomePage> HomePages { get; set; }
        public ICollection<Banner> Banners { get; set; }
        public ICollection<HomePageInformation> HomePageInformation { get; set; }
        public ICollection<SellCondition> SellConditions { get; set; }
        public ICollection<Office> Offices { get; set; }
        public ICollection<AdvantageOfPurchasing> AdvantageOfPurchasings { get; set; }
        public ICollection<ConditionsOfPurchasing> ConditionsOfPurchasings { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<HousingProject> HousingProjects { get; set; }
        public TitleAndSubtitle TitleAndSubtitle { get; set; }
        public SocialMedia SocialMedia { get; set; }
        public string Con1 { get; set; }
        public string Con2 { get; set; }
        public string Con3 { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string ContentName { get; set; }
    }
}
