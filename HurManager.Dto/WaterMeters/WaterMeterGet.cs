namespace HurManager.Dto.WaterMeters
{
    public class WaterMeterGet
    {
        public int WaterMeterId { get; set; }

        public string FactoryNumber { get; set; }

        public int Reading { get; set; }

        public int HouseId { get; set; }
    }
}
