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
    public class AdvantageMap : IEntityTypeConfiguration<Advantage>
    {
        public void Configure(EntityTypeBuilder<Advantage> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Title).HasMaxLength(100);
            builder.Property(a => a.Title).IsRequired(true);

            builder.HasOne<Language>(a => a.Language).WithMany(c => c.Advantages).HasForeignKey(a => a.LanguageId);

            builder.ToTable("Advantage");

            builder.HasData(
                new Advantage {
                    Id = 1,
                    LanguageId = 1,
                    Title = "Sizin xalis gəliriniz"
                },
                new Advantage
                {
                    Id = 2,
                    LanguageId = 2,
                    Title = "Your net income"
                },
                new Advantage
                {
                    Id = 3,
                    LanguageId = 3,
                    Title = "Ваш чистый доход"
                },
                new Advantage
                {
                    Id = 4,
                    LanguageId = 1,
                    Title = "İdarəetmə xərcləri"
                },
                new Advantage
                {
                    Id = 5,
                    LanguageId = 2,
                    Title = "Management costs"
                },
                new Advantage
                {
                    Id = 6,
                    LanguageId = 3,
                    Title = "Расходы на управление"
                },
                new Advantage
                {
                    Id = 7,
                    LanguageId = 1,
                    Title = "Komunal xərclər"
                },
                new Advantage
                {
                    Id = 8,
                    LanguageId = 2,
                    Title = "Utility costs"
                },
                new Advantage
                {
                    Id = 9,
                    LanguageId = 3,
                    Title = "Коммунальные расходы"
                },
                new Advantage
                {
                    Id = 10,
                    LanguageId = 1,
                    Title = "Xidmət xərclər"
                },
                new Advantage
                {
                    Id = 11,
                    LanguageId = 2,
                    Title = "Service costs"
                },
                new Advantage
                {
                    Id = 12,
                    LanguageId = 3,
                    Title = "Затраты на обслуживание"
                },
                new Advantage
                {
                    Id = 13,
                    LanguageId = 1,
                    Title = "Gəlir və mənfəət vergisi"
                },
                new Advantage
                {
                    Id = 14,
                    LanguageId = 2,
                    Title = "Income and profit tax"
                },
                new Advantage
                {
                    Id = 15,
                    LanguageId = 3,
                    Title = "Подоходный налог и налог на прибыль"
                },
                new Advantage
                {
                    Id = 16,
                    LanguageId = 1,
                    Title = "Sair forsmajor xərclər"
                },
                new Advantage
                {
                    Id = 17,
                    LanguageId = 2,
                    Title = "Other force majeure expenses"
                },
                new Advantage
                {
                    Id = 18,
                    LanguageId = 3,
                    Title = "Прочие форс-мажорные расходы"
                }
            );
        }
    }
}
