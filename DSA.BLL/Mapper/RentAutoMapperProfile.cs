using AutoMapper;
using DSA.BLL.Dto.Rents;
using DSA.Domain.Rents;

namespace DSA.BLL.Mapper
{
    public class RentAutoMapperProfile : Profile
    {
        public RentAutoMapperProfile()
        {
            CreateMap<Rent, RentDto>()
                .ForMember(x => x.CustomerName, t => t.MapFrom(p => p.Customer.FullName))
                .ForMember(x => x.DronModel, t => t.MapFrom(p => p.Dron.DronModel.Name))
                .ForMember(x => x.DronCompany, t => t.MapFrom(p => p.Dron.DronModel.DronCompany.Name))
                .ForMember(x => x.DronType, t => t.MapFrom(p => p.Dron.DronModel.DronType.Name))
                .ForMember(x => x.DronDescription, t => t.MapFrom(p => p.Dron.DronModel.Description))
                .ForMember(x => x.DronDailyCosts, t => t.MapFrom(p => p.Dron.DailyCosts))
                .ForMember(x => x.RentDaysCount, t => t.MapFrom(p => (p.EndDate - p.StartDate).Days));

            CreateMap<AddRentDto, Rent>()
                .ForMember(x => x.RentId, t => t.Ignore())
                .ForMember(x => x.Dron, t => t.Ignore())
                .ForMember(x => x.Customer, t => t.Ignore());
        }
    }
}
