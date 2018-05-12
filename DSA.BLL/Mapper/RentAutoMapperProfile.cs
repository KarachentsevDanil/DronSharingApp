using AutoMapper;
using SAT.BLL.Dto.Rents;
using SAT.Domain.Rents;
using System;

namespace SAT.BLL.Mapper
{
    public class RentAutoMapperProfile : Profile
    {
        public RentAutoMapperProfile()
        {
            CreateMap<Rent, RentDto>()
                .ForMember(x => x.CustomerEmail, t => t.MapFrom(p => p.Customer.Email))
                .ForMember(x => x.CustomerName, t => t.MapFrom(p => p.Customer.FullName))
                .ForMember(x => x.OwnerEmail, t => t.MapFrom(p => p.AirTaxi.Customer.Email))
                .ForMember(x => x.OwnerName, t => t.MapFrom(p => p.AirTaxi.Customer.FullName))
                .ForMember(x => x.OwnerId, t => t.MapFrom(p => p.AirTaxi.CustomerId))
                .ForMember(x => x.AirTaxiModel, t => t.MapFrom(p => p.AirTaxi.AirTaxiModel.Name))
                .ForMember(x => x.AirTaxiCompany, t => t.MapFrom(p => p.AirTaxi.AirTaxiModel.Company.Name))
                .ForMember(x => x.AirTaxiType, t => t.MapFrom(p => p.AirTaxi.AirTaxiModel.Type.Name))
                .ForMember(x => x.AirTaxiDescription, t => t.MapFrom(p => p.AirTaxi.AirTaxiModel.Description))
                .ForMember(x => x.AirTaxiDailyCosts, t => t.MapFrom(p => p.AirTaxi.DailyCosts))
                .ForMember(x => x.RentDaysCount, t => t.MapFrom(p => (p.EndDate - p.StartDate).Days))
                .ForMember(x => x.TotalCosts, t => t.MapFrom(p => (p.EndDate - p.StartDate).Days * p.AirTaxi.DailyCosts))
                .ForMember(x => x.StartDate, t => t.MapFrom(p => p.StartDate.ToShortDateString()))
                .ForMember(x => x.EndDate, t => t.MapFrom(p => p.EndDate.ToShortDateString()))
                .ForMember(x => x.AirTaxiPhoto, t => t.Ignore());

            CreateMap<Rent, RentCalendarDto>()
                .ForMember(x => x.Title, t => t.MapFrom(p => $"{p.Customer.FullName} - {p.Customer.Email}"))
                .ForMember(x => x.Start, t => t.MapFrom(p => p.StartDate.ToString("O")))
                .ForMember(x => x.End, t => t.MapFrom(p => p.EndDate.ToString("O")))
                .ForMember(x => x.Color, t => t.MapFrom(p => DateTime.UtcNow > p.EndDate ? "#607D8B" : "#2196F3"));

            CreateMap<AddRentDto, Rent>()
                .ForMember(x => x.RentId, t => t.Ignore())
                .ForMember(x => x.AirTaxi, t => t.Ignore())
                .ForMember(x => x.Customer, t => t.Ignore());
        }
    }
}
