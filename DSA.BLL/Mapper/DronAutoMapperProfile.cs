using AutoMapper;
using DSA.BLL.Dto.Drons;
using DSA.Domain.Drons;

namespace DSA.BLL.Mapper
{
    public class DronAutoMapperProfile : Profile
    {
        public DronAutoMapperProfile()
        {
            CreateMap<AddDronCompanyDto, DronCompany>()
                .ForMember(x => x.DronCompanyId, t => t.Ignore())
                .ForMember(x => x.Drons, t => t.Ignore());

            CreateMap<AddDronTypeDto, DronType>()
                .ForMember(x => x.DronTypeId, t => t.Ignore())
                .ForMember(x => x.Drons, t => t.Ignore());

            CreateMap<AddDronModelDto, DronModel>()
                .ForMember(x => x.DronModelId, t => t.Ignore())
                .ForMember(x => x.DronType, t => t.Ignore())
                .ForMember(x => x.DronCompany, t => t.Ignore())
                .ForMember(x => x.Photo, t => t.Ignore())
                .ForMember(x => x.Drons, t => t.Ignore());

            CreateMap<AddDronDto, Dron>()
                .ForMember(x => x.DronId, t => t.Ignore())
                .ForMember(x => x.DronModel, t => t.Ignore())
                .ForMember(x => x.Customer, t => t.Ignore())
                .ForMember(x => x.Rents, t => t.Ignore());

            CreateMap<DronCompany, DronCompanyDto>();

            CreateMap<DronType, DronTypeDto>();

            CreateMap<DronModel, DronModelDto>()
                .ForMember(x => x.DronCompanyName, t => t.MapFrom(p => p.DronCompany.Name))
                .ForMember(x => x.DronTypeName, t => t.MapFrom(p => p.DronType.Name))
                .ForMember(x => x.Photo, t => t.Ignore());

            CreateMap<Dron, DronDto>()
                .ForMember(x => x.DronCompanyName, t => t.MapFrom(p => p.DronModel.DronCompany.Name))
                .ForMember(x => x.DronTypeName, t => t.MapFrom(p => p.DronModel.DronType.Name))
                .ForMember(x => x.CustomerName, t => t.MapFrom(p => p.Customer.FullName))
                .ForMember(x => x.DronModelName, t => t.MapFrom(p => p.DronModel.Name))
                .ForMember(x => x.DronDescription, t => t.MapFrom(p => p.DronModel.Description))
                .ForMember(x => x.DronPhoto, t => t.Ignore());
        }
    }
}
