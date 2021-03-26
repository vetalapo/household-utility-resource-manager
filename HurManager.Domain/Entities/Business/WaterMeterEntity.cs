using HurManager.Domain.Entities.Interfaces;

namespace HurManager.Domain.Entities.Business
{
    public class WaterMeterEntity : IEntity
    {
        public int WaterMeterId { get; set; }

        public string FactoryNumber { get; set; }

        public int Reading { get; set; }

        public int HouseId { get; set; }

        public HouseEntity House { get; set; }
    }
}
