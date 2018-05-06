using AutoMapper;
using SAT.BLL.Dto.Rents;
using SAT.Domain.Rents;

namespace SAT.BLL.Mapper
{
    public class RentAutoMapperProfile : Profile
    {
        public RentAutoMapperProfile()
        {
            CreateMap<Rent, RentDto>()
                .ForMember(x => x.CustomerName, t => t.MapFrom(p => p.Customer.FullName))
                .ForMember(x => x.AirTaxiModel, t => t.MapFrom(p => p.AirTaxi.AirTaxiModel.Name))
                .ForMember(x => x.AirTaxiCompany, t => t.MapFrom(p => p.AirTaxi.AirTaxiModel.Company.Name))
                .ForMember(x => x.AirTaxiType, t => t.MapFrom(p => p.AirTaxi.AirTaxiModel.Type.Name))
                .ForMember(x => x.AirTaxiDescription, t => t.MapFrom(p => p.AirTaxi.AirTaxiModel.Description))
                .ForMember(x => x.AirTaxiDailyCosts, t => t.MapFrom(p => p.AirTaxi.DailyCosts))
                .ForMember(x => x.RentDaysCount, t => t.MapFrom(p => (p.EndDate - p.StartDate).Days))
                .ForMember(x => x.AirTaxiPhoto, t => t.Ignore());

            CreateMap<AddRentDto, Rent>()
                .ForMember(x => x.RentId, t => t.Ignore())
                .ForMember(x => x.AirTaxi, t => t.Ignore())
                .ForMember(x => x.Customer, t => t.Ignore());
        }
    }
}
