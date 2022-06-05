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
    public class OfficeMap : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.OfficeName).HasMaxLength(50);
            builder.Property(o => o.OfficeName).IsRequired(true);
            builder.Property(o => o.Address).HasMaxLength(150);
            builder.Property(o => o.Address).IsRequired(true);
            builder.Property(o => o.Number1).HasMaxLength(50);
            builder.Property(o => o.Number1).IsRequired(true);
            builder.Property(o => o.Number2).HasMaxLength(50);
            builder.Property(o => o.Number3).HasMaxLength(50);
            builder.Property(o => o.Email).HasMaxLength(150);
            builder.Property(o => o.Email).IsRequired(true);
            builder.Property(o => o.WorkDays).HasMaxLength(50);
            builder.Property(o => o.WorkDays).IsRequired(true);
            builder.Property(o => o.WorkHours).HasMaxLength(50);
            builder.Property(o => o.WorkHours).IsRequired(true);
            builder.Property(o => o.MapUrl).IsRequired(true);
            builder.Property(o => o.LanguageGroupId).IsRequired(true);

            builder.HasOne<Language>(a => a.Language).WithMany(c => c.Offices).HasForeignKey(a => a.LanguageId);

            builder.ToTable("Office");
            Guid languageGroupId1 = Guid.NewGuid();
            Guid languageGroupId2 = Guid.NewGuid();
            builder.HasData(
                new Office {
                    Id = 1,
                    LanguageId = 1,
                    LanguageGroupId = languageGroupId1,
                    OfficeName = "Səbayıl ofisi",
                    Address = "2054, Filan küçə, Səbayıl rayonu, Bakı şəhəri, Azərbaycan",
                    Number1 = "+380 (629) 53 01 91",
                    Email = "info@asrz.com.ua",
                    WorkDays = "Bazar ertəsi - Şənbə",
                    WorkHours = "09:00 - 19:00",
                    MapUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3778.379899589656!2d49.8313591598617!3d40.39711718830179!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40307d7d1d7e6e47%3A0x18844c22b43281ea!2s123%20Game%20Lounge!5e1!3m2!1saz!2s!4v1629146008779!5m2!1saz!2s\" width = \"600\" height = \"450\" style=\"border: 0\" allowfullscreen = \"\" loading = \"lazy\"></iframe>",
                    IsMain = true
                },
                new Office
                {
                    Id = 2,
                    LanguageId = 2,
                    LanguageGroupId = languageGroupId1,
                    OfficeName = "Sabail office",
                    Address = "2054, Filan street, Sabail district, Baku city, Azerbaijan",
                    Number1 = "+380 (629) 53 01 91",
                    Email = "info@asrz.com.ua",
                    WorkDays = "Monday - Saturday",
                    WorkHours = "09:00 - 19:00",
                    MapUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3778.379899589656!2d49.8313591598617!3d40.39711718830179!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40307d7d1d7e6e47%3A0x18844c22b43281ea!2s123%20Game%20Lounge!5e1!3m2!1saz!2s!4v1629146008779!5m2!1saz!2s\" width = \"600\" height = \"450\" style=\"border: 0\" allowfullscreen = \"\" loading = \"lazy\"></iframe>",
                    IsMain = true
                },
                new Office
                {
                    Id = 3,
                    LanguageId = 3,
                    LanguageGroupId = languageGroupId1,
                    OfficeName = "Сабаильский офис",
                    Address = "2054, улица Филана, Сабаильский район, город Баку, Азербайджан",
                    Number1 = "+380 (629) 53 01 91",
                    Email = "info@asrz.com.ua",
                    WorkDays = "Понедельник - Суббота",
                    WorkHours = "09:00 - 19:00",
                    MapUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3778.379899589656!2d49.8313591598617!3d40.39711718830179!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40307d7d1d7e6e47%3A0x18844c22b43281ea!2s123%20Game%20Lounge!5e1!3m2!1saz!2s!4v1629146008779!5m2!1saz!2s\" width = \"600\" height = \"450\" style=\"border: 0\" allowfullscreen = \"\" loading = \"lazy\"></iframe>",
                    IsMain = true
                },
                new Office
                {
                    Id = 4,
                    LanguageId = 1,
                    LanguageGroupId = languageGroupId2,
                    OfficeName = "Qax ofisi",
                    Address = "2054, Filan küçə, Səbayıl rayonu, Bakı şəhəri, Azərbaycan",
                    Number1 = "+380 (629) 53 01 91",
                    Email = "info@asrz.com.ua",
                    WorkDays = "Bazar ertəsi - Şənbə",
                    WorkHours = "09:00 - 19:00",
                    MapUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3778.379899589656!2d49.8313591598617!3d40.39711718830179!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40307d7d1d7e6e47%3A0x18844c22b43281ea!2s123%20Game%20Lounge!5e1!3m2!1saz!2s!4v1629146008779!5m2!1saz!2s\" width = \"600\" height = \"450\" style=\"border: 0\" allowfullscreen = \"\" loading = \"lazy\"></iframe>"
                },
                new Office
                {
                    Id = 5,
                    LanguageId = 2,
                    LanguageGroupId = languageGroupId2,
                    OfficeName = "Qax office",
                    Address = "2054, Filan street, Sabail district, Baku city, Azerbaijan",
                    Number1 = "+380 (629) 53 01 91",
                    Email = "info@asrz.com.ua",
                    WorkDays = "Monday - Saturday",
                    WorkHours = "09:00 - 19:00",
                    MapUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3778.379899589656!2d49.8313591598617!3d40.39711718830179!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40307d7d1d7e6e47%3A0x18844c22b43281ea!2s123%20Game%20Lounge!5e1!3m2!1saz!2s!4v1629146008779!5m2!1saz!2s\" width = \"600\" height = \"450\" style=\"border: 0\" allowfullscreen = \"\" loading = \"lazy\"></iframe>"
                },
                new Office
                {
                    Id = 6,
                    LanguageId = 3,
                    LanguageGroupId = languageGroupId2,
                    OfficeName = "Офис Qax",
                    Address = "2054, улица Филана, Сабаильский район, город Баку, Азербайджан",
                    Number1 = "+380 (629) 53 01 91",
                    Email = "info@asrz.com.ua",
                    WorkDays = "Понедельник - Суббота",
                    WorkHours = "09:00 - 19:00",
                    MapUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3778.379899589656!2d49.8313591598617!3d40.39711718830179!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40307d7d1d7e6e47%3A0x18844c22b43281ea!2s123%20Game%20Lounge!5e1!3m2!1saz!2s!4v1629146008779!5m2!1saz!2s\" width = \"600\" height = \"450\" style=\"border: 0\" allowfullscreen = \"\" loading = \"lazy\"></iframe>"
                }
            );
        }
    }
}
