using IlisuHiltopHeaven.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace IlisuHiltopHeaven.Data.Concrete.EntityFramework.Mappings
{
    public class BannerMap : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Title).HasMaxLength(100);
            builder.Property(p => p.Title).IsRequired(true);
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.Description).IsRequired(true);
            builder.Property(p => p.ImageOne).HasMaxLength(250);
            builder.Property(p => p.ImageOne).IsRequired(true);
            builder.Property(p => p.ImageTwo).HasMaxLength(250);
            builder.Property(p => p.ImageTwo).IsRequired(true);
            builder.Property(p => p.ImageThree).HasMaxLength(250);
            builder.Property(p => p.ImageThree).IsRequired(true);
            builder.Property(p => p.ImageFour).HasMaxLength(250);
            builder.Property(p => p.ImageFour).IsRequired(true);
            builder.Property(p => p.ImageFive).HasMaxLength(250);
            builder.Property(p => p.ImageFive).IsRequired(true);
            builder.Property(p => p.VideoUrl).HasMaxLength(300);
            builder.Property(p => p.VideoUrl).IsRequired(true);
            builder.Property(p => p.LanguageGroupId).IsRequired(true);

            builder.HasOne<Language>(p => p.Language).WithMany(l => l.Banners).HasForeignKey(p => p.LanguageId);
            Guid languageGroupId = Guid.NewGuid();
            builder.HasData(
                new Banner
                {
                    Id = 1,
                    LanguageId = 1,
                    LanguageGroupId = languageGroupId,
                    Title = "İlisu Hiltop Heaven",
                    Description = "Sizin üçün yeni iş mənzili yaratmaq üçün Azərbaycanda yaşayış və qeyri-yaşayış sahələrini birləşdirən ilk şəxs olduq. Qafqaz dağlarının ətəyində, Kumruk çayı və İlisu dərəsinə baxan 1 hektar özəl ərazidə inşa etdiyimiz 11 binada, ehtiyaclarınıza uyğun bir ərazidə iş mənzilləri təklif edirik.",
                    ImageOne = "banner/bannerimage1.jpg",
                    ImageTwo = "banner/bannerimage2.jpg",
                    ImageThree = "banner/bannerimage3.jpg",
                    ImageFour = "banner/bannerimage4.jpg",
                    ImageFive = "banner/bannerimage5.jpg",
                    VideoUrl = "video url"
                },
                new Banner
                {
                    Id = 2,
                    LanguageId = 2,
                    LanguageGroupId = languageGroupId,
                    Title = "Ilisu Hiltop Heaven",
                    Description = "We are the first in Azerbaijan to combine residential and non-residential to create a new business-housing model for you. We offer business apartments in 11 buildings built on 1 hectare of private land with a view of the Kumruk River and Ilisu gorge at the foot of the Caucasus Mountains.",
                    ImageOne = "banner/bannerimage1.jpg",
                    ImageTwo = "banner/bannerimage2.jpg",
                    ImageThree = "banner/bannerimage3.jpg",
                    ImageFour = "banner/bannerimage4.jpg",
                    ImageFive = "banner/bannerimage5.jpg",
                    VideoUrl = "video url"
                },
                new Banner
                {
                    Id = 3,
                    LanguageId = 3,
                    LanguageGroupId = languageGroupId,
                    Title = "Илису Хилтоп Хевен",
                    Description = "Мы первые в Азербайджане объединили жилое и нежилое, чтобы создать для вас новую модель бизнес-жилья. У подножия Кавказских гор, в 11 зданиях, которые мы построили на 1 гектаре частной земли с видом на реку Кумрук и ущелье Илису, мы предлагаем бизнес-апартаменты в районе, который соответствует вашим потребностям.",
                    ImageOne = "banner/bannerimage1.jpg",
                    ImageTwo = "banner/bannerimage2.jpg",
                    ImageThree = "banner/bannerimage3.jpg",
                    ImageFour = "banner/bannerimage4.jpg",
                    ImageFive = "banner/bannerimage5.jpg",
                    VideoUrl = "video url"
                }
            );
        }
    }
}
