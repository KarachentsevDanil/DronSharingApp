using AutoMapper;
using SAT.BLL.Dto.Customers;
using SAT.Domain.Customers;

namespace SAT.BLL.Mapper
{
    public class CustomerAutoMapperProfile : Profile
    {
        public CustomerAutoMapperProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(x => x.CustomerId, t => t.MapFrom(p => p.Id))
                .ForMember(x => x.Role, t => t.MapFrom(p => p.Role.ToString()));
        }
    }
}
