using HurManager.Core.Services.Session;
using HurManager.Dal.Context.Modeling;
using HurManager.Domain.Entities.Business;

using Microsoft.EntityFrameworkCore;

namespace HurManager.Dal.Context
{
    public class HurManagerContext : DbContext
    {
        public HurManagerContext(DbContextOptions<HurManagerContext> options) : base(options)
        {
        }

        public virtual DbSet<HouseEntity> Houses { get; set; }

        public virtual DbSet<WaterMeterEntity> WaterMeters { get; set; }

        public ISession RelatedSession { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ApplyConfiguration(new HouseEntityConfiguration())
                .ApplyConfiguration(new WaterMeterEntityConfiguration());
        }
    }
}
