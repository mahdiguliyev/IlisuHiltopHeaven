using IlisuHiltopHeaven.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace IlisuHiltopHeaven.Data.Concrete.EntityFramework.Mappings
{
    public class TravelMap : IEntityTypeConfiguration<Travel>
    {
        public void Configure(EntityTypeBuilder<Travel> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.Property(t => t.Title).HasMaxLength(100);
            builder.Property(t => t.Title).IsRequired(true);
            builder.Property(t => t.Description).IsRequired(true);
            builder.Property(t => t.ImageOne).HasMaxLength(250);
            builder.Property(t => t.ImageOne).IsRequired(true);
            builder.Property(t => t.ImageTwo).HasMaxLength(250);
            builder.Property(t => t.ImageTwo).IsRequired(true);
            builder.Property(t => t.ImageThree).HasMaxLength(250);
            builder.Property(t => t.ImageThree).IsRequired(true);
            builder.Property(t => t.ImageFour).HasMaxLength(250);
            builder.Property(t => t.ImageFour).IsRequired(true);
            builder.Property(t => t.ImageFive).HasMaxLength(250);
            builder.Property(t => t.ImageFive).IsRequired(true);
            builder.Property(t => t.ImageSix).HasMaxLength(250);
            builder.Property(t => t.ImageSix).IsRequired(true);
            builder.Property(t => t.LanguageGroupId).IsRequired(true);

            builder.HasOne<Language>(t => t.Language).WithMany(l => l.Travels).HasForeignKey(t => t.LanguageId);
            Guid languageGroupId = Guid.NewGuid();
            builder.HasData(
                new Travel
                {
                    Id = 1,
                    LanguageId = 1,
                    LanguageGroupId = languageGroupId,
                    Title = "Biznes-mənzillərin alqı-satqısı üçün edilən səyahət",
                    Description = "Şirkətimiz tərəfindən mütəmadi olaraq mənzillərlə və əraziylə detallı tanış olmaq üçün satış turlar təşkil edilir. Bunun üçün sizin cəmi bir neçə gününüz kifayətdir ki hərşeyi öz göznüzlə görüb, istədiyiniz mənzili seçməyiniz, ehtiyac olduğu təqdirdə yerində konsultasiya almaq və alqı satqını həyata keçirə bilərsiniz. Bununla bərabər siz həm də zamanınızı maraqlı keçirərək İlisunun qəıdim mədəniyyət və tarixiylə tanış olursunuz. Turlarla bağlı daha ətraflı məlumata ehtiyacınız varsa məmnuniyyətlə bütün suallarınızı cavablandırmağa hazırıq. Saytda yerlışdirilən əlaqə nömrələri vasitəsiylə satış ofisiylə əlaqə saxlaya bilərsiniz.",
                    ImageOne = "toure/toureimage1.png",
                    ImageTwo = "toure/toureimage2.png",
                    ImageThree = "toure/toureimage3.png",
                    ImageFour = "toure/toureimage4.png",
                    ImageFive = "toure/toureimage5.png",
                    ImageSix = "toure/toureimage6.png"
                },
                new Travel
                {
                    Id = 2,
                    LanguageId = 2,
                    LanguageGroupId = languageGroupId,
                    Title = "Travel for the purchase and sale of business apartments",
                    Description = "Our company regularly organizes sales tours to get acquainted with the apartments and the area in detail. All you need is a few days to see everything with your own eyes, choose the apartment you want, get advice on the spot and make a purchase, if necessary. At the same time, you will have an interesting time and get acquainted with the ancient culture and history of Ilisu. If you need more information about the tours, we are happy to answer all your questions. You can contact the sales office through the contact numbers posted on the site.",
                    ImageOne = "toure/toureimage1.png",
                    ImageTwo = "toure/toureimage2.png",
                    ImageThree = "toure/toureimage3.png",
                    ImageFour = "toure/toureimage4.png",
                    ImageFive = "toure/toureimage5.png",
                    ImageSix = "toure/toureimage6.png"
                },
                new Travel
                {
                    Id = 3,
                    LanguageId = 3,
                    LanguageGroupId = languageGroupId,
                    Title = "Путешествие по покупке и продаже бизнес-квартир",
                    Description = "Наша компания регулярно организует торговые туры для детального ознакомления с квартирами и районом. Достаточно несколько дней, чтобы увидеть все своими глазами, выбрать нужную квартиру, получить консультацию на месте и при необходимости совершить покупку. Заодно интересно проведете время и познакомитесь с древней культурой и историей Илису. Если вам нужна дополнительная информация о турах, мы с радостью ответим на все ваши вопросы. Связаться с офисом продаж можно по контактным номерам, указанным на сайте.",
                    ImageOne = "toure/toureimage1.png",
                    ImageTwo = "toure/toureimage2.png",
                    ImageThree = "toure/toureimage3.png",
                    ImageFour = "toure/toureimage4.png",
                    ImageFive = "toure/toureimage5.png",
                    ImageSix = "toure/toureimage6.png"
                }
            );
        }
    }
}
