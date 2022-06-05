using IlisuHiltopHeaven.Data.Concrete.EntityFramework.Mappings;
using IlisuHiltopHeaven.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IlisuHiltopHeaven.Data.Concrete.EntityFramework.Context
{
    public class IlisuHiltopHeavenContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public IlisuHiltopHeavenContext(DbContextOptions<IlisuHiltopHeavenContext> options) : base(options)
        {

        }

        public DbSet<Advantage> Advantages { get; set; }
        public DbSet<AdvantageHilltop> AdvantageHilltops { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<HomePageInformation> HomePageInformations { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceAdvantage> ServiceAdvantages { get; set; }
        public DbSet<ServiceHiltopAdvantage> ServiceHiltopAdvantages { get; set; }
        public DbSet<Language> Languages { get; set; }

        public DbSet<HomePage> HomePages { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<SellCondition> SellConditions { get; set; }

        public DbSet<AdvantageOfPurchasing> AdvantageOfPurchasings { get; set; }
        public DbSet<ConditionsOfPurchasing> ConditionsOfPurchasings { get; set; }
        public DbSet<TitleAndSubtitle> TitleAndSubtitles { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<HousingProject> HousingProjects { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RoleMap());
            builder.ApplyConfiguration(new RoleClaimMap());
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new UserClaimMap());
            builder.ApplyConfiguration(new UserLoginMap());
            builder.ApplyConfiguration(new UserTokenMap());
            builder.ApplyConfiguration(new UserRoleMap());
            builder.ApplyConfiguration(new AdvantageMap());
            builder.ApplyConfiguration(new AdvantageHilltopMap());

            builder.ApplyConfiguration(new HomePageInformationMap());
            builder.ApplyConfiguration(new OfficeMap());
            builder.ApplyConfiguration(new ServiceAdvantageMap());
            builder.ApplyConfiguration(new ServiceHiltopAdvantageMap());
            builder.ApplyConfiguration(new ServiceMap());
            builder.ApplyConfiguration(new LanguageMap());

            builder.ApplyConfiguration(new HomePageMap());
            builder.ApplyConfiguration(new BannerMap());
            builder.ApplyConfiguration(new ProjectMap());
            builder.ApplyConfiguration(new TravelMap());
            builder.ApplyConfiguration(new SellConditionMap());

            builder.ApplyConfiguration(new AdvantageOfPurchasingMap());
            builder.ApplyConfiguration(new ConditionOfPurchasingMap());
            builder.ApplyConfiguration(new TitleAndSubtitleMap());
            builder.ApplyConfiguration(new SocialMediaMap());
            builder.ApplyConfiguration(new HousingProjectMap());

            builder.ApplyConfiguration(new ContactMap());
        }
    }
}
