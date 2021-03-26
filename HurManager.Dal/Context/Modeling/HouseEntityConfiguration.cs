using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HurManager.Domain.Entities.Business;
using HurManager.Dal.Context.Seeders;

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
