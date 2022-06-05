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
    public class ConditionOfPurchasingMap : IEntityTypeConfiguration<ConditionsOfPurchasing>
    {
        public void Configure(EntityTypeBuilder<ConditionsOfPurchasing> builder)
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

            builder.HasOne<Language>(a => a.Language).WithMany(c => c.ConditionsOfPurchasings).HasForeignKey(a => a.LanguageId);

            builder.ToTable("ConditionsOfPurchasings");
            Guid languageGroupId = Guid.NewGuid();
            builder.HasData(
                new ConditionsOfPurchasing
                {
                    Id = 1,
                    LanguageId = 1,
                    LanguageGroupId = languageGroupId,
                    MainTitle = "Biz mənzilləri necə əldə edə bilərik?",
                    Title1 = "Tam ödənişlə satış",
                    Description1 = "Tam ödəniş krediti ilə satışa dair üç sətirlik cümlə ola bilər burda ki, standart görünsün.",
                    Image1 = "sprite.svg#icon-payment",
                    Title2 = "İpoteka krediti ilə satış",
                    Description2 = "İpoteka krediti ilə satışa dair üç sətirlik cümlə ola bilər burda ki, standars görünsün.",
                    Image2 = "sprite.svg#icon-bank",
                    Title3 = "Qısamüddətli daxili kreditlə satış",
                    Description3 = "Qısamüddətli daxili krediti ilə satışa dair üç sətirlik cümlə ola bilər burda.",
                    Image3 = "sprite.svg#icon-loan"
                },
                new ConditionsOfPurchasing
                {
                    Id = 2,
                    LanguageId = 2,
                    LanguageGroupId = languageGroupId,
                    MainTitle = "How can we get apartments?",
                    Title1 = "Full sale",
                    Description1 = "There may be a three-line sentence about selling with a full repayment loan here to make it look standard.",
                    Image1 = "sprite.svg#icon-payment",
                    Title2 = "Sale with a mortgage loan",
                    Description2 = "There may be a three-line sentence about selling a mortgage loan here that looks standard.",
                    Image2 = "sprite.svg#icon-bank",
                    Title3 = "Sale on short-term domestic credit",
                    Description3 = "There may be a three-line sentence about selling with a short-term domestic loan here.",
                    Image3 = "sprite.svg#icon-loan"
                },
                new ConditionsOfPurchasing
                {
                    Id = 3,
                    LanguageId = 3,
                    LanguageGroupId = languageGroupId,
                    MainTitle = "Как мы можем получить квартиры?",
                    Title1 = "Полная продажа",
                    Description1 = "Здесь может быть предложение из трех строк о продаже с полным погашением кредита, чтобы это выглядело стандартным.",
                    Image1 = "sprite.svg#icon-payment",
                    Title2 = "Продажа с ипотечной ссудой",
                    Description2 = "Здесь может быть предложение из трех строк о продаже ипотечного кредита, которое выглядит стандартным.",
                    Image2 = "sprite.svg#icon-bank",
                    Title3 = "Продажа по краткосрочному внутреннему кредиту",
                    Description3 = "Здесь может быть приговор о продаже с краткосрочным внутренним займом.",
                    Image3 = "sprite.svg#icon-loan"
                }
            );
        }
    }
}
