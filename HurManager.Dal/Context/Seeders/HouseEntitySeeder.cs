using HurManager.Domain.Entities.Business;

namespace HurManager.Dal.Context.Seeders
{
    internal static class HouseEntitySeeder
    {
        public static HouseEntity[] GetSeedData()
        {
            return new[]
            {
                new HouseEntity
                {
                    HouseId = 1,
                    Address = "2094 Arrowood Drive"
                },
                new HouseEntity
                {
                    HouseId = 2,
                    Address = "421 Oakwood Avenue"
                },
                new HouseEntity
                {
                    HouseId = 3,
                    Address = "4927 Stoneybrook Road"
                },
                new HouseEntity
                {
                    HouseId = 4,
                    Address = "2144 College View"
                },
                new HouseEntity
                {
                    HouseId = 5,
                    Address = "2568 Stone Lane"
                },
                new HouseEntity
                {
                    HouseId = 6,
                    Address = "3465 Worley Avenue"
                },
                new HouseEntity
                {
                    HouseId = 7,
                    Address = "5003 Hidden Valley Road"
                },
                new HouseEntity
                {
                    HouseId = 8,
                    Address = "2022 Karen Lane"
                },
                new HouseEntity
                {
                    HouseId = 9,
                    Address = "2905 Crestview Terrace"
                },
                new HouseEntity
                {
                    HouseId = 10,
                    Address = "567 Upton Avenue"
                }
            };
        }
    }
}
