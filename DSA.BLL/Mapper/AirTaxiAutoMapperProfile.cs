using AutoMapper;
using SAT.BLL.Dto.AirTaxies;
using SAT.Domain.AirTaxies;
using System;

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
                .ForMember(x => x.Photo, p => p.MapFrom(t => Convert.FromBase64String(t.Photo)))
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
                .ForMember(x => x.Photo, p => p.MapFrom(t => t.Photo != null && t.Photo.Length > 0 ? $"data:image/png;base64,{Convert.ToBase64String(t.Photo)}" : string.Empty));

            CreateMap<AirTaxi, AirTaxiDto>()
                .ForMember(x => x.AirTaxiCompanyName, t => t.MapFrom(p => p.AirTaxiModel.Company.Name))
                .ForMember(x => x.AirTaxiTypeName, t => t.MapFrom(p => p.AirTaxiModel.Type.Name))
                .ForMember(x => x.CustomerName, t => t.MapFrom(p => p.Customer.FullName))
                .ForMember(x => x.AirTaxiModelName, t => t.MapFrom(p => p.AirTaxiModel.Name))
                .ForMember(x => x.AirTaxiDescription, t => t.MapFrom(p => p.AirTaxiModel.Description))
                .ForMember(x => x.AirTaxiMaximumRangeFlight, t => t.MapFrom(p => p.AirTaxiModel.MaximumRangeFlight))
                .ForMember(x => x.AirTaxiCapacity, t => t.MapFrom(p => p.AirTaxiModel.Capacity))
                .ForMember(x => x.AirTaxiPhoto, p => p.MapFrom(t => t.AirTaxiModel.Photo != null && t.AirTaxiModel.Photo.Length > 0 ? $"data:image/png;base64,{Convert.ToBase64String(t.AirTaxiModel.Photo)}" : string.Empty));
        }
    }
}
