using HurManager.Domain.Entities.Business;

namespace HurManager.Dal.Context.Seeders
{
    internal static class WaterMeterEntitySeeder
    {
        public static WaterMeterEntity[] GetSeedData()
        {
            return new[]
            {
                new WaterMeterEntity
                {
                    WaterMeterId = 1,
                    HouseId = 1,
                    FactoryNumber = "A701959",
                    Reading = 2649
                },
                new WaterMeterEntity
                {
                    WaterMeterId = 2,
                    HouseId = 2,
                    FactoryNumber = "B176459",
                    Reading = 6754
                },
                new WaterMeterEntity
                {
                    WaterMeterId = 3,
                    HouseId = 3,
                    FactoryNumber = "C057998",
                    Reading = 4582
                },
                new WaterMeterEntity
                {
                    WaterMeterId = 4,
                    HouseId = 4,
                    FactoryNumber = "A297539",
                    Reading = 4868
                },
                new WaterMeterEntity
                {
                    WaterMeterId = 5,
                    HouseId = 5,
                    FactoryNumber = "N934471",
                    Reading = 8796
                },
                new WaterMeterEntity
                {
                    WaterMeterId = 6,
                    HouseId = 6,
                    FactoryNumber = "Z435565",
                    Reading = 2910
                },
                new WaterMeterEntity
                {
                    WaterMeterId = 7,
                    HouseId = 7,
                    FactoryNumber = "A199350",
                    Reading = 3338
                },
                new WaterMeterEntity
                {
                    WaterMeterId = 8,
                    HouseId = 8,
                    FactoryNumber = "Z347827",
                    Reading = 3183
                },
                new WaterMeterEntity
                {
                    WaterMeterId = 9,
                    HouseId = 9,
                    FactoryNumber = "Q481678",
                    Reading = 5930
                }
            };
        }
    }
}
