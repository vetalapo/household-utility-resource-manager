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
            this.CreateMap<HouseEntity, HouseGet>()
                .ForMember(
                    x => x.Id,
                    x => x.MapFrom(o => o.HouseId)
                )
                .ForMember(
                    x => x.WaterMeterId,
                    x => x.MapFrom(o => o.WaterMeter.WaterMeterId)
                );

            this.CreateMap<HouseAdd, HouseEntity>();
            
            this.CreateMap<HouseUpdate, HouseEntity>()
                .ForMember(
                    x => x.HouseId,
                    x => x.MapFrom(o => o.Id)
                );

            this.CreateMap<HouseEntity, HouseSummary>()
                .ForMember(
                    x => x.Id,
                    x => x.MapFrom(o => o.HouseId)
                )
                .ForMember(
                    x => x.WaterMeterId,
                    x => x.MapFrom(o => o.WaterMeter.WaterMeterId)
                )
                .ForMember(
                    x => x.WaterMeterReading,
                    x => x.MapFrom(o => o.WaterMeter.Reading)
                )
                .ForMember(
                    x => x.WaterMeterFactoryNumber,
                    x => x.MapFrom(o => o.WaterMeter.FactoryNumber)
                );
        }

        private void WaterMeterMap()
        {
            this.CreateMap<WaterMeterEntity, WaterMeterGet>()
                .ForMember(
                    x => x.Id,
                    x => x.MapFrom(o => o.WaterMeterId)
                );

            this.CreateMap<WaterMeterAdd, WaterMeterEntity>();
            
            this.CreateMap<WaterMeterUpdate, WaterMeterEntity>()
                .ForMember(
                    x => x.WaterMeterId,
                    x => x.MapFrom(o => o.Id)
                );
        }
    }
}
