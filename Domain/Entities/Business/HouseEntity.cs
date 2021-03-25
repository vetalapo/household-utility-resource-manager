using HurManager.Domain.Entities.Interfaces;

namespace HurManager.Domain.Entities.Business
{
    public class HouseEntity : IEntity
    {
        public int HouseId { get; set; }

        public string Address { get; set; }

        public WaterMeterEntity WaterMeter { get; set; }
    }
}
