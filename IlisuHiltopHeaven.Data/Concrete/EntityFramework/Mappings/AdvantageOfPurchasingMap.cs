using IlisuHiltopHeaven.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Data.Concrete.EntityFramework.Mappings
{
    public class AdvantageOfPurchasingMap : IEntityTypeConfiguration<AdvantageOfPurchasing>
    {
        public void Configure(EntityTypeBuilder<AdvantageOfPurchasing> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.Title1).HasMaxLength(100);
            builder.Property(s => s.Title1).IsRequired(true);
            builder.Property(s => s.Description1).IsRequired(true);
            builder.Property(s => s.Image1).HasMaxLength(250);
            builder.Property(s => s.Image1).IsRequired(true);

            builder.Property(s => s.Title2).HasMaxLength(100);
            builder.Property(s => s.Title2).IsRequired(true);
            builder.Property(s => s.Description2).IsRequired(true);
            builder.Property(s => s.Image2).HasMaxLength(250);
            builder.Property(s => s.Image2).IsRequired(true);

            builder.Property(s => s.Title3).HasMaxLength(100);
            builder.Property(s => s.Title3).IsRequired(true);
            builder.Property(s => s.Description3).IsRequired(true);
            builder.Property(s => s.Image3).HasMaxLength(250);
            builder.Property(s => s.Image3).IsRequired(true);

            builder.Property(s => s.LanguageGroupId).IsRequired(true);

            builder.HasOne<Language>(a => a.Language).WithMany(c => c.AdvantageOfPurchasings).HasForeignKey(a => a.LanguageId);

            builder.ToTable("AdvantageOfPurchasings");
            Guid languageGroupId = Guid.NewGuid();
            builder.HasData(
                new AdvantageOfPurchasing
                {
                    Id = 1,
                    LanguageId = 1,
                    LanguageGroupId = languageGroupId,
                    MainTitle = "Mənzilləri almaqla nə əldə edirik?",
                    Title1 = "Daşınmaz əmlak",
                    Description1 = "Siz öz biznes-mənzillerinizi icareye verərək stabil gəlir əldə edirsiniz. Sizin qazancınız sizdən və bizdən asılı olacaq. Nə qədər çox icarəyə versəz bir o qədər də gəliriniz çox olacaq.",
                    Image1 = "sprite.svg#icon-key",
                    Title2 = "Əlavə gəlir",
                    Description2 = "Siz öz biznes-mənzillerinizi icareye verərək stabil gəlir əldə edirsiniz. Sizin qazancınız sizdən və bizdən asılı olacaq. Nə qədər çox icarəyə versəz bir o qədər də gəliriniz çox olacaq.",
                    Image2 = "sprite.svg#icon-profit",
                    Title3 = "Sərmayəmizi qorumaq",
                    Description3 = "Siz öz biznes-mənzillerinizi icareye verərək stabil gəlir əldə edirsiniz. Sizin qazancınız sizdən və bizdən asılı olacaq. Nə qədər çox icarəyə versəz bir o qədər də gəliriniz çox olacaq.",
                    Image3 = "sprite.svg#icon-money"
                },
                new AdvantageOfPurchasing
                {
                    Id = 2,
                    LanguageId = 2,
                    LanguageGroupId = languageGroupId,
                    MainTitle = "What do we get by buying apartments?",
                    Title1 = "Real Estate",
                    Description1 = "You get a steady income by renting out your business apartments. Your earnings will depend on you and us. The more you rent, the more income you will have.",
                    Image1 = "sprite.svg#icon-key",
                    Title2 = "Extra income",
                    Description2 = "You get a steady income by renting out your business apartments. Your earnings will depend on you and us. The more you rent, the more income you will have.",
                    Image2 = "sprite.svg#icon-profit",
                    Title3 = "Protect our capital",
                    Description3 = "You get a steady income by renting out your business apartments. Your earnings will depend on you and us. The more you rent, the more income you will have.",
                    Image3 = "sprite.svg#icon-money"
                },
                new AdvantageOfPurchasing
                {
                    Id = 3,
                    LanguageId = 3,
                    LanguageGroupId = languageGroupId,
                    MainTitle = "Что мы получаем, покупая квартиры?",
                    Title1 = "Недвижимость",
                    Description1 = "Сдавая в аренду бизнес-апартаменты, вы получаете стабильный доход. Ваш заработок будет зависеть от вас и нас. Чем больше вы арендуете, тем больше у вас будет доход.",
                    Image1 = "sprite.svg#icon-key",
                    Title2 = "Дополнительный доход",
                    Description2 = "Сдавая в аренду бизнес-апартаменты, вы получаете стабильный доход. Ваш заработок будет зависеть от вас и нас. Чем больше вы арендуете, тем больше у вас будет доход.",
                    Image2 = "sprite.svg#icon-profit",
                    Title3 = "Защитите нашу столицу",
                    Description3 = "Сдавая в аренду бизнес-апартаменты, вы получаете стабильный доход. Ваш заработок будет зависеть от вас и нас. Чем больше вы арендуете, тем больше у вас будет доход.",
                    Image3 = "sprite.svg#icon-money"
                }
            );
        }
    }
}
