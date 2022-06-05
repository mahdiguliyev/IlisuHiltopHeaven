using IlisuHiltopHeaven.Shared.Entities.Abstract;
using System.Collections.Generic;

namespace IlisuHiltopHeaven.Entities.Concrete
{
    public class Language : IEntity
    {
        public virtual int Id { get; set; }
        public string LanguageCode { get; set; }
        public ICollection<HomePageInformation> HomePageInformations { get; set; }
        public ICollection<Advantage> Advantages { get; set; }
        public ICollection<AdvantageHilltop> AdvantageHilltops { get; set; }
        public ICollection<Office> Offices { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<HomePage> HomePages { get; set; }
        public ICollection<Banner> Banners { get; set; }
        public ICollection<SellCondition> SellConditions { get; set; }
        public ICollection<Travel> Travels { get; set; }
        public ICollection<Project> Projects { get; set; }

        public ICollection<AdvantageOfPurchasing> AdvantageOfPurchasings { get; set; }
        public ICollection<ConditionsOfPurchasing> ConditionsOfPurchasings { get; set; }
        public ICollection<TitleAndSubtitle> TitleAndSubtitles { get; set; }
        public ICollection<HousingProject> HousingProjects { get; set; }
    }
}
