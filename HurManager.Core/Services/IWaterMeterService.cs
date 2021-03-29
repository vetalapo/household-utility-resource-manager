using System.Threading.Tasks;

using HurManager.Dto.WaterMeters;

namespace HurManager.Core.Services
{
    public interface IWaterMeterService
    {
        Task AddAsync(WaterMeterAdd dto);

        Task RemoveAsync(int id);

        Task<WaterMeterGet> GetAsync(int id);

        Task UpdateAsync(WaterMeterUpdate dto);

        Task AddReadingByHouseIdAsync(WaterMeterReadingHouseIdAdd dto);

        Task AddReadingByFactoryNumberAsync(WaterMeterReadingFactoryNbrAdd dto);
    }
}
