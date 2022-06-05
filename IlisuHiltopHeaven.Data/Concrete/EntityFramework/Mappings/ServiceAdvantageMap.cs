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
    public class ServiceAdvantageMap : IEntityTypeConfiguration<ServiceAdvantage>
    {
        public void Configure(EntityTypeBuilder<ServiceAdvantage> builder)
        {
            builder.HasKey(sa => new { sa.ServiceId, sa.AdvantageId });
            builder.HasOne(sa => sa.Service)
                .WithMany(s => s.ServiceAdvantages)
                .HasForeignKey(sa => sa.ServiceId).OnDelete(DeleteBehavior.Cascade); ;
            builder.HasOne(sa => sa.Advantage)
                .WithMany(a => a.ServiceAdvantages)
                .HasForeignKey(sa => sa.AdvantageId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
