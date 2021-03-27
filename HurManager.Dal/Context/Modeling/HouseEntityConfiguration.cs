using HurManager.Dal.Context.Seeders;
using HurManager.Domain.Entities.Business;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HurManager.Dal.Context.Modeling
{
    public class HouseEntityConfiguration : IEntityTypeConfiguration<HouseEntity>
    {
        public void Configure(EntityTypeBuilder<HouseEntity> modelBuilder)
        {
            modelBuilder.ToTable("House");

            modelBuilder.HasKey(x => x.HouseId);

            modelBuilder
                .HasIndex(i => i.Address)
                .IsUnique();

            modelBuilder.HasData(HouseEntitySeeder.GetSeedData());
        }
    }
}
