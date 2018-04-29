using AutoMapper;
using SAT.BLL.Dto.AirTaxies;
using SAT.Domain.AirTaxies;

namespace SAT.BLL.Mapper
{
    public class AirTaxiAutoMapperProfile : Profile
    {
        public AirTaxiAutoMapperProfile()
        {
            CreateMap<AddAirTaxiCompanyDto, AirTaxiCompany>()
                .ForMember(x => x.AirTaxiCompanyId, t => t.Ignore())
                .ForMember(x => x.TaxiModels, t => t.Ignore());

            CreateMap<AddAirTaxiTypeDto, AirTaxiType>()
                .ForMember(x => x.AirTaxiTypeId, t => t.Ignore())
                .ForMember(x => x.Taxies, t => t.Ignore());

            CreateMap<AddAirTaxiModelDto, AirTaxiModel>()
                .ForMember(x => x.AirTaxiModelId, t => t.Ignore())
                .ForMember(x => x.Type, t => t.Ignore())
                .ForMember(x => x.Company, t => t.Ignore())
                .ForMember(x => x.Photo, t => t.Ignore())
                .ForMember(x => x.AirTaxies, t => t.Ignore());

            CreateMap<AddAirTaxiDto, AirTaxi>()
                .ForMember(x => x.AirTaxiId, t => t.Ignore())
                .ForMember(x => x.AirTaxiModel, t => t.Ignore())
                .ForMember(x => x.Customer, t => t.Ignore())
                .ForMember(x => x.Rents, t => t.Ignore());

            CreateMap<AirTaxiCompany, AirTaxiCompanyDto>();

            CreateMap<AirTaxiType, AirTaxiTypeDto>();

            CreateMap<AirTaxiModel, AirTaxiModelDto>()
                .ForMember(x => x.AirTaxiCompanyName, t => t.MapFrom(p => p.Company.Name))
                .ForMember(x => x.AirTaxiTypeName, t => t.MapFrom(p => p.Type.Name))
                .ForMember(x => x.Photo, t => t.Ignore());

            CreateMap<AirTaxi, AirTaxiDto>()
                .ForMember(x => x.AirTaxiCompanyName, t => t.MapFrom(p => p.AirTaxiModel.Company.Name))
                .ForMember(x => x.AirTaxiTypeName, t => t.MapFrom(p => p.AirTaxiModel.Type.Name))
                .ForMember(x => x.CustomerName, t => t.MapFrom(p => p.Customer.FullName))
                .ForMember(x => x.AirTaxiModelName, t => t.MapFrom(p => p.AirTaxiModel.Name))
                .ForMember(x => x.AirTaxiDescription, t => t.MapFrom(p => p.AirTaxiModel.Description))
                .ForMember(x => x.AirTaxiMaximumRangeFlight, t => t.MapFrom(p => p.AirTaxiModel.MaximumRangeFlight))
                .ForMember(x => x.AirTaxiCapacity, t => t.MapFrom(p => p.AirTaxiModel.Capacity))
                .ForMember(x => x.AirTaxiPhoto, t => t.Ignore());
        }
    }
}
