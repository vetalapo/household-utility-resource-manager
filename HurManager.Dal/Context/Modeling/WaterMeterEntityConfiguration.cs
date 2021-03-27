using HurManager.Dal.Context.Seeders;
using HurManager.Domain.Entities.Business;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HurManager.Dal.Context.Modeling
{
    public class WaterMeterEntityConfiguration : IEntityTypeConfiguration<WaterMeterEntity>
    {
        public void Configure(EntityTypeBuilder<WaterMeterEntity> modelBuilder)
        {
            modelBuilder.ToTable("WaterMeter");

            modelBuilder.HasKey(x => x.WaterMeterId);

            modelBuilder
                .HasIndex(i => i.FactoryNumber)
                .IsUnique();

            modelBuilder
                .HasOne(h => h.House)
                .WithOne(m => m.WaterMeter)
                .HasForeignKey<WaterMeterEntity>(x => x.HouseId);

            modelBuilder.HasData(WaterMeterEntitySeeder.GetSeedData());
        }
    }
}
