using IlisuHiltopHeaven.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace IlisuHiltopHeaven.Data.Concrete.EntityFramework.Mappings
{
    public class HomePageMap : IEntityTypeConfiguration<HomePage>
    {
        public void Configure(EntityTypeBuilder<HomePage> builder)
        {
            builder.HasKey(hp => hp.Id);
            builder.Property(hp => hp.Id).ValueGeneratedOnAdd();
            builder.Property(hp => hp.Title).HasMaxLength(100);
            builder.Property(hp => hp.Title).IsRequired(true);
            builder.Property(hp => hp.PageName).HasMaxLength(20);
            builder.Property(hp => hp.PageName).IsRequired(true);
            builder.Property(hp => hp.Image).HasMaxLength(250);
            builder.Property(hp => hp.LanguageGroupId).IsRequired(true);

            builder.HasOne<Language>(hp => hp.Language).WithMany(l => l.HomePages).HasForeignKey(hp => hp.LanguageId);

            Guid languageGroupId1 = Guid.NewGuid();
            Guid languageGroupId2 = Guid.NewGuid();
            Guid languageGroupId3 = Guid.NewGuid();
            Guid languageGroupId4 = Guid.NewGuid();

            builder.HasData(
                new HomePage
                {
                    Id = 1,
                    LanguageId = 1,
                    LanguageGroupId = languageGroupId1,
                    Title = "Huzurlu yaşam və sığortalı gəlir təminatı",
                    PageName = "homepage",
                    Image = "homepageinf/homepageimage.jpg"
                },
                new HomePage
                {
                    Id = 2,
                    LanguageId = 2,
                    LanguageGroupId = languageGroupId1,
                    Title = "Secure living and insured income",
                    PageName = "homepage",
                    Image = "homepageinf/homepageimage.jpg"
                },
                new HomePage
                {
                    Id = 3,
                    LanguageId = 3,
                    LanguageGroupId = languageGroupId1,
                    Title = "Безопасная жизнь и застрахованный доход",
                    PageName = "homepage",
                    Image = "homepageinf/homepageimage.jpg"
                },
                new HomePage
                {
                    Id = 4,
                    LanguageId = 1,
                    LanguageGroupId = languageGroupId2,
                    Title = "Layihə səhifəsi",
                    PageName = "project",
                    Image = "homepageinf/projectpage.jpg"
                },
                new HomePage
                {
                    Id = 5,
                    LanguageId = 2,
                    LanguageGroupId = languageGroupId2,
                    Title = "Project page",
                    PageName = "project",
                    Image = "homepageinf/projectpage.jpg"
                },
                new HomePage
                {
                    Id = 6,
                    LanguageId = 3,
                    LanguageGroupId = languageGroupId2,
                    Title = "Страница проекта",
                    PageName = "project",
                    Image = "homepageinf/projectpage.jpg"
                },
                new HomePage
                {
                    Id = 7,
                    LanguageId = 1,
                    LanguageGroupId = languageGroupId3,
                    Title = "Xidmətlər sahifəsi",
                    PageName = "services",
                    Description = "1 ha torpaq sahəsində 11 ədəd 3 mərtəbəli yaşayış binası, açıq uşaq meydançası və 2 ədəd iki mərtəbəli qeyri-yaşayış binası nəzərdə tutulmuşdur. 3 mərtəbəli yaşayış binasının ümumi sahəsi 570 kv. metrdir. Qeyri yaşayış binalarının hər birinin ümumi sahəsi 500 kv. metrdir",
                    Image = "homepageinf/servicespage.jpg"
                },
                new HomePage
                {
                    Id = 8,
                    LanguageId = 2,
                    LanguageGroupId = languageGroupId3,
                    Title = "Services page",
                    PageName = "services",
                    Description = "There are 11 3-storey residential buildings, an open children's playground and 2 two-storey non-residential buildings on 1 hectare of land. The total area of the 3-storey residential building is 570 sq.m. meters. The total area of each of the non-residential buildings is 500 sq.m. meters.",
                    Image = "homepageinf/servicespage.jpg"
                },
                new HomePage
                {
                    Id = 9,
                    LanguageId = 3,
                    LanguageGroupId = languageGroupId3,
                    Title = "Страница услуг",
                    PageName = "services",
                    Description = "На 1 га земли расположены 11 3-х этажных жилых домов, открытая детская площадка и 2 2-х этажных нежилых дома. Общая площадь 3-х этажного жилого дома 570 кв.м. метров. Общая площадь каждого нежилого дома составляет 500 кв.м. метров.",
                    Image = "homepageinf/servicespage.jpg"
                },
                new HomePage
                {
                    Id = 10,
                    LanguageId = 1,
                    LanguageGroupId = languageGroupId4,
                    Title = "Bizimlə əlaqə",
                    PageName = "contact",
                    Description = "Biznes-mənzillərlə bağlı daha ətraflı məlumata ehtiyacınız varsa məmnuniyyətlə bütün suallarınızı cavablandırmağa hazırıq. Əlaqə nömrələri vasitəsiylə satış ofisiylə əlaqə saxlaya bilərsiniz.",
                    Image = ""
                },
                new HomePage
                {
                    Id = 11,
                    LanguageId = 2,
                    LanguageGroupId = languageGroupId4,
                    Title = "Contact us",
                    PageName = "contact",
                    Description = "If you need more information about business apartments, we are happy to answer all your questions. You can contact the sales office via contact numbers.",
                    Image = ""
                },
                new HomePage
                {
                    Id = 12,
                    LanguageId = 3,
                    LanguageGroupId = languageGroupId4,
                    Title = "Связаться с нами",
                    PageName = "contact",
                    Description = "Если вам нужна дополнительная информация о бизнес-квартирах, мы с радостью ответим на все ваши вопросы. Вы можете связаться с офисом продаж по контактным телефонам.",
                    Image = ""
                }
            );
        }
    }
}
