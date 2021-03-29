namespace HurManager.Dto.Houses
{
    public class HouseSummary
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public int? WaterMeterId { get; set; }

        public int WaterMeterReading { get; set; }

        public string WaterMeterFactoryNumber { get; set; }
    }
}
