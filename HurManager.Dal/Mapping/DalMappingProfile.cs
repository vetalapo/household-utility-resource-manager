using AutoMapper;
using HurManager.Domain.Entities.Business;
using HurManager.Dto.Houses;
using HurManager.Dto.WaterMeters;

namespace HurManager.Dal.Mapping
{
    internal class DalMappingProfile : Profile
    {
        public DalMappingProfile()
        {
            try
            {
                this.HouseMap();
                this.WaterMeterMap();
            }
            catch
            {
            }
        }

        private void HouseMap()
        {
            this.CreateMap<HouseEntity, HouseGet>();
            this.CreateMap<HouseEntity, HouseAdd>();
            this.CreateMap<HouseEntity, HouseUpdate>();
        }

        private void WaterMeterMap()
        {
            this.CreateMap<WaterMeterEntity, WaterMeterGet>();
            this.CreateMap<WaterMeterEntity, WaterMeterAdd>();
            this.CreateMap<WaterMeterEntity, WaterMeterUpdate>();
        }
    }
}
