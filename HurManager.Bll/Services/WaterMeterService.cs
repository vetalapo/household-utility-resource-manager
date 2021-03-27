using System;
using System.Threading.Tasks;

using AutoMapper;

using HurManager.Core.Services;
using HurManager.Core.Services.Session;
using HurManager.Domain.Entities.Business;
using HurManager.Dto.WaterMeters;

using Microsoft.EntityFrameworkCore;

namespace HurManager.Bll.Services
{
    public class WaterMeterService : IWaterMeterService
    {
        private readonly ISession _session;
        private readonly IMapper _mapper;

        public WaterMeterService(ISession session, IMapper mapper)
        {
            this._session = session;
            this._mapper = mapper;
        }

        public async Task AddAsync(WaterMeterAdd dto)
        {
            var waterMeter = this._mapper.Map<WaterMeterEntity>(dto);

            await this._session.AddEntityAsync(waterMeter);
        }

        public async Task<WaterMeterGet> GetAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            var entity = await this._session.Query<WaterMeterEntity>()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.HouseId == id);

            var result = this._mapper.Map<WaterMeterGet>(entity);

            return result;
        }

        public async Task RemoveAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            var entity = await this._session.Query<WaterMeterEntity>()
                .SingleOrDefaultAsync(x => x.HouseId == id);

            await this._session.RemoveEntityAsync(entity);
        }

        public async Task UpdateAsync(WaterMeterUpdate dto)
        {
            var entity = await this._session.Query<WaterMeterEntity>().SingleOrDefaultAsync(x => x.HouseId == dto.Id);

            this._mapper.Map(dto, entity);

            await this._session.FlushAsync();
        }
    }
}
