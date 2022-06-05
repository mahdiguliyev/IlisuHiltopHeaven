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
    public class LanguageMap : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).ValueGeneratedOnAdd();
            builder.Property(l => l.LanguageCode).HasMaxLength(10);
            builder.Property(l => l.LanguageCode).IsRequired(true);

            builder.ToTable("Languages");

            builder.HasData(
                new Language
                {
                    Id = 1,
                    LanguageCode = "az"
                },
                new Language
                {
                    Id = 2,
                    LanguageCode = "eng"
                },
                new Language
                {
                    Id = 3,
                    LanguageCode = "rus"
                }
            );
        }
    }
}
