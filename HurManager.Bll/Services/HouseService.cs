using System;
using System.Threading.Tasks;

using AutoMapper;

using HurManager.Core.Services;
using HurManager.Core.Services.Session;
using HurManager.Domain.Entities.Business;
using HurManager.Dto.Houses;

using Microsoft.EntityFrameworkCore;

namespace HurManager.Bll.Services
{
    public class HouseService : IHouseService
    {
        private readonly ISession _session;
        private readonly IMapper _mapper;

        public HouseService(ISession session, IMapper mapper)
        {
            this._session = session;
            this._mapper = mapper;
        }

        public async Task AddAsync(HouseAdd dto)
        {
            var house = this._mapper.Map<HouseEntity>(dto);

            await this._session.AddEntityAsync(house);
        }

        public async Task<HouseGet> GetAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            var entity = await this._session.Query<HouseEntity>()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.HouseId == id);

            var result = this._mapper.Map<HouseGet>(entity);

            return result;
        }

        public async Task RemoveAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            var entity = await this._session.Query<HouseEntity>()
                .SingleOrDefaultAsync(x => x.HouseId == id);

            await this._session.RemoveEntityAsync(entity);
        }

        public async Task UpdateAsync(HouseUpdate dto)
        {
            var entity = await this._session.Query<HouseEntity>().SingleOrDefaultAsync(x => x.HouseId == dto.Id);

            this._mapper.Map(dto, entity);

            await this._session.FlushAsync();
        }
    }
}
