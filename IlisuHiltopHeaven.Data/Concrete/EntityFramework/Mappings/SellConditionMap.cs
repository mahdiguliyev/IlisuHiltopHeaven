using IlisuHiltopHeaven.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace IlisuHiltopHeaven.Data.Concrete.EntityFramework.Mappings
{
    public class SellConditionMap : IEntityTypeConfiguration<SellCondition>
    {
        public void Configure(EntityTypeBuilder<SellCondition> builder)
        {
            builder.HasKey(sc => sc.Id);
            builder.Property(sc => sc.Id).ValueGeneratedOnAdd();
            builder.Property(sc => sc.Title).HasMaxLength(100);
            builder.Property(sc => sc.Title).IsRequired(true);
            builder.Property(sc => sc.Description).IsRequired(true);
            builder.Property(sc => sc.LanguageGroupId).IsRequired(true);

            builder.HasOne<Language>(sc => sc.Language).WithMany(l => l.SellConditions).HasForeignKey(sc => sc.LanguageId);
            Guid languageGroupId = Guid.NewGuid();
            builder.HasData(
                new SellCondition
                {
                    Id = 1,
                    LanguageId = 1,
                    LanguageGroupId = languageGroupId,
                    Title = "Satış və sənədləşmə",
                    Description = "Kompleksə daxil olan bütün yaşayış binaları çıxarışla təmin edilmişdir. Əldə edəcəyiniz sahəyə uyğun mənzillərə dair çıxarış notarial qaydada təsdiq edilmiş alqı-satqı müqaviləsinin əsasında dövlət reyestrindən çıxarışla sizə təqdim ediləcəkdir."
                },
                new SellCondition
                {
                    Id = 2,
                    LanguageId = 2,
                    Title = "Sales and documentation",
                    LanguageGroupId = languageGroupId,
                    Description = "All residential buildings included in the complex are provided with an extract. An extract on the apartments corresponding to the area you will acquire will be provided to you with an extract from the state register on the basis of a notarized purchase agreement."
                },
                new SellCondition
                {
                    Id = 3,
                    LanguageId = 3,
                    Title = "Продажа и документация",
                    LanguageGroupId = languageGroupId,
                    Description = "На все жилые дома, входящие в комплекс, предоставляется выписка. Вам будет предоставлена ​​выписка о квартирах соответствующей площади, которую вы получите, вместе с выпиской из государственного реестра на основании нотариально удостоверенного договора купли-продажи."
                }
            );
        }
    }
}
