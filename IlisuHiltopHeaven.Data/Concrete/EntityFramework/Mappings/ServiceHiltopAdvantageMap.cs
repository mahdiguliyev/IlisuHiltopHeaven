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
    public class ServiceHiltopAdvantageMap : IEntityTypeConfiguration<ServiceHiltopAdvantage>
    {
        public void Configure(EntityTypeBuilder<ServiceHiltopAdvantage> builder)
        {
            builder.HasKey(sa => new { sa.ServiceId, sa.AdvantageHiltopId });
            builder.HasOne(sa => sa.Service)
                .WithMany(s => s.ServiceHiltopAdvantages)
                .HasForeignKey(sa => sa.ServiceId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(sa => sa.AdvantageHilltop)
                .WithMany(a => a.ServiceHiltopAdvantages)
                .HasForeignKey(sa => sa.AdvantageHiltopId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
