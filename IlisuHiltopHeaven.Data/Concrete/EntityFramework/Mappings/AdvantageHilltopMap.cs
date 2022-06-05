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
    public class AdvantageHilltopMap : IEntityTypeConfiguration<AdvantageHilltop>
    {
        public void Configure(EntityTypeBuilder<AdvantageHilltop> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Title).HasMaxLength(100);
            builder.Property(a => a.Title).IsRequired(true);

            builder.HasOne<Language>(a => a.Language).WithMany(c => c.AdvantageHilltops).HasForeignKey(a => a.LanguageId);

            builder.ToTable("AdvantageHiltop");

            builder.HasData(
                new AdvantageHilltop
                {
                    Id = 1,
                    LanguageId = 1,
                    Title = "İdarəetmə xərcləri"
                },
                new AdvantageHilltop
                {
                    Id = 2,
                    LanguageId = 2,
                    Title = "Management costs"
                },
                new AdvantageHilltop
                {
                    Id = 3,
                    LanguageId = 3,
                    Title = "Расходы на управление"
                },
                new AdvantageHilltop
                {
                    Id = 4,
                    LanguageId = 1,
                    Title = "Komunal xərclər"
                },
                new AdvantageHilltop
                {
                    Id = 5,
                    LanguageId = 2,
                    Title = "Utility costs"
                },
                new AdvantageHilltop
                {
                    Id = 6,
                    LanguageId = 3,
                    Title = "Коммунальные расходы"
                },
                new AdvantageHilltop
                {
                    Id = 7,
                    LanguageId = 1,
                    Title = "Xidmət xərclər"
                },
                new AdvantageHilltop
                {
                    Id = 8,
                    LanguageId = 2,
                    Title = "Service costs"
                },
                new AdvantageHilltop
                {
                    Id = 9,
                    LanguageId = 3,
                    Title = "Затраты на обслуживание"
                },
                new AdvantageHilltop
                {
                    Id = 10,
                    LanguageId = 1,
                    Title = "Gəlir və mənfəət vergisi"
                },
                new AdvantageHilltop
                {
                    Id = 11,
                    LanguageId = 2,
                    Title = "Income and profit tax"
                },
                new AdvantageHilltop
                {
                    Id = 12,
                    LanguageId = 3,
                    Title = "Подоходный налог и налог на прибыль"
                },
                new AdvantageHilltop
                {
                    Id = 13,
                    LanguageId = 1,
                    Title = "Sair forsmajor xərclər"
                },
                new AdvantageHilltop
                {
                    Id = 14,
                    LanguageId = 2,
                    Title = "Other force majeure expenses"
                },
                new AdvantageHilltop
                {
                    Id = 15,
                    LanguageId = 3,
                    Title = "Прочие форс-мажорные расходы"
                }
            );
        }
    }
}
