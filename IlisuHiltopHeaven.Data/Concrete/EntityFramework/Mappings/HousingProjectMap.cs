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
    public class HousingProjectMap : IEntityTypeConfiguration<HousingProject>
    {
        public void Configure(EntityTypeBuilder<HousingProject> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.MainTitle).HasMaxLength(150);
            builder.Property(s => s.MainTitle).IsRequired(true);
            builder.Property(s => s.Description).IsRequired(true);
            builder.Property(s => s.floor1).HasMaxLength(100);
            builder.Property(s => s.floor1).IsRequired(true);
            builder.Property(s => s.Image1).HasMaxLength(250);
            builder.Property(s => s.Image1).IsRequired(true);

            builder.Property(s => s.floor2).HasMaxLength(100);
            builder.Property(s => s.floor2).IsRequired(true);
            builder.Property(s => s.Image2).HasMaxLength(250);
            builder.Property(s => s.Image2).IsRequired(true);

            builder.Property(s => s.floor3).HasMaxLength(100);
            builder.Property(s => s.floor3).IsRequired(true);
            builder.Property(s => s.Image3).HasMaxLength(250);
            builder.Property(s => s.Image3).IsRequired(true);
            builder.Property(s => s.LanguageGroupId).IsRequired(true);

            builder.HasOne<Language>(a => a.Language).WithMany(c => c.HousingProjects).HasForeignKey(a => a.LanguageId);

            builder.ToTable("HousingProjects");
            Guid languageGroupId = Guid.NewGuid();
            builder.HasData(
                new HousingProject
                {
                    Id = 1,
                    LanguageId = 1,
                    LanguageGroupId = languageGroupId,
                    MainTitle = "Mənzillərin layihəsi",
                    Description = "Layihenin planı haqqında qısa mətn olmalıdır burda. bunlar şərti mətndir, sizə kompleksə gəlmədən öz biznesinizi idarə etmə, nəzarətdə saxlama və icarəyə verə bilmə imkanı yaradır. Mənzilləri öz şəxsi istirahətiniz və yaşayışınız üçün də istifadə edə bilərsiniz.",
                    floor1 = "1-ci mərtəbə",
                    floor2 = "2-ci mərtəbə",
                    floor3 = "3-ci mərtəbə",
                    Image1 = "housingproject/project1.jpg",
                    Image2 = "housingproject/project2.jpg",
                    Image3 = "housingproject/project3.jpg"
                },
                new HousingProject
                {
                    Id = 2,
                    LanguageId = 2,
                    LanguageGroupId = languageGroupId,
                    MainTitle = "Housing project",
                    Description = "There should be a short text about the project plan here. these are conditional texts that allow you to manage, control and lease your business without having to come to the complex. You can also use the apartments for your personal recreation and living.",
                    floor1 = "1st floor",
                    floor2 = "2nd floor",
                    floor3 = "3rd floor",
                    Image1 = "housingproject/project1.jpg",
                    Image2 = "housingproject/project2.jpg",
                    Image3 = "housingproject/project3.jpg"
                },
                new HousingProject
                {
                    Id = 3,
                    LanguageId = 3,
                    LanguageGroupId = languageGroupId,
                    MainTitle = "Жилищный проект",
                    Description = "Здесь должен быть краткий текст о плане проекта. это условные тексты, которые позволяют управлять, контролировать и сдавать в аренду свой бизнес, не заходя в комплекс. Вы также можете использовать апартаменты для личного отдыха и проживания.",
                    floor1 = "1-й этаж",
                    floor2 = "2-й этаж",
                    floor3 = "3-й этаж",
                    Image1 = "housingproject/project1.jpg",
                    Image2 = "housingproject/project2.jpg",
                    Image3 = "housingproject/project3.jpg"
                }
            );
        }
    }
}
