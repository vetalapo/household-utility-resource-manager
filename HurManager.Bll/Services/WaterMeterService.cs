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
            if (dto.Reading < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(dto.Reading));
            }

            if (dto.HouseId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(dto.HouseId));
            }

            if (string.IsNullOrWhiteSpace(dto.FactoryNumber))
            {
                throw new ArgumentNullException(nameof(dto.FactoryNumber));
            }

            dto.FactoryNumber = dto.FactoryNumber.Trim();

            var waterMeter = this._mapper.Map<WaterMeterEntity>(dto);

            await this._session.AddEntityAsync(waterMeter);
        }

        public async Task AddReadingByFactoryNumberAsync(WaterMeterReadingFactoryNbrAdd dto)
        {
            if (dto.Reading < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(dto.Reading));
            }

            if (string.IsNullOrWhiteSpace(dto.FactoryNumber))
            {
                throw new ArgumentNullException(nameof(dto.FactoryNumber));
            }

            dto.FactoryNumber = dto.FactoryNumber.Trim();

            var entity = await this._session.Query<WaterMeterEntity>().SingleOrDefaultAsync(x => x.FactoryNumber == dto.FactoryNumber) 
                ?? throw new Exception("Entity not found");

            if (entity.Reading > dto.Reading)
            {
                throw new ArgumentOutOfRangeException(nameof(dto.Reading), "Reading cannot be less than current DB value");
            }

            entity.Reading = dto.Reading;

            await this._session.FlushAsync();
        }

        public async Task AddReadingByHouseIdAsync(WaterMeterReadingHouseIdAdd dto)
        {
            if (dto.Reading < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(dto.Reading));
            }

            if (dto.HouseId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(dto.HouseId));
            }

            var entity = await this._session.Query<WaterMeterEntity>().SingleOrDefaultAsync(x => x.HouseId == dto.HouseId)
                ?? throw new Exception("Entity not found"); ;

            if (entity.Reading > dto.Reading)
            {
                throw new ArgumentOutOfRangeException(nameof(dto.Reading), "Reading cannot be less than current DB value");
            }

            entity.Reading = dto.Reading;

            await this._session.FlushAsync();
        }

        public async Task<WaterMeterGet> GetAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            var entity = await this._session.Query<WaterMeterEntity>()
                .AsNoTracking()
                .Include(x => x.House)
                .SingleOrDefaultAsync(x => x.WaterMeterId == id);

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
                .SingleOrDefaultAsync(x => x.WaterMeterId == id);

            await this._session.RemoveEntityAsync(entity);
        }

        public async Task UpdateAsync(WaterMeterUpdate dto)
        {
            if (dto.Reading < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(dto.Reading));
            }

            if (dto.Id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(dto.Id));
            }

            if (dto.HouseId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(dto.HouseId));
            }

            if (string.IsNullOrWhiteSpace(dto.FactoryNumber))
            {
                throw new ArgumentNullException(nameof(dto.FactoryNumber));
            }

            var entity = await this._session.Query<WaterMeterEntity>().SingleOrDefaultAsync(x => x.WaterMeterId == dto.Id);

            if (entity.Reading > dto.Reading)
            {
                throw new ArgumentOutOfRangeException(nameof(dto.Reading), "Reading cannot be less than current DB value");
            }

            this._mapper.Map(dto, entity);

            await this._session.FlushAsync();
        }
    }
}
