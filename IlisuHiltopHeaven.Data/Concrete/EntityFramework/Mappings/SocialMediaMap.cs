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
    public class SocialMediaMap : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.PhoneNumber).HasMaxLength(50);
            builder.Property(s => s.PhoneNumber).IsRequired(true);
            builder.Property(s => s.WhatsappUrl).HasMaxLength(250);
            builder.Property(s => s.InstagramUrl).HasMaxLength(250);
            builder.Property(s => s.FacebookUrl).HasMaxLength(250);
            builder.Property(s => s.YoutubeUrl).HasMaxLength(250);

            builder.ToTable("SocialMedias");

            builder.HasData(
                new SocialMedia
                {
                    Id = 1,
                    PhoneNumber = "+994 50 200 00 00",
                    WhatsappUrl = "https://wa.me/994502000000",
                    FacebookUrl = "https://www.facebook.com",
                    InstagramUrl = "https://www.instagram.com",
                    YoutubeUrl = "https://www.youtube.com"
                }    
            );
        }
    }
}
