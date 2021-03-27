using System.Threading.Tasks;

using HurManager.Dto.Houses;

namespace HurManager.Core.Services
{
    public interface IHouseService
    {
        Task AddAsync(HouseAdd dto);

        Task RemoveAsync(int id);

        Task<HouseGet> GetAsync(int id);

        Task UpdateAsync(HouseUpdate dto);
    }
}
