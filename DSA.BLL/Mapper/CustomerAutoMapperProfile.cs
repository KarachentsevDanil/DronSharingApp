using AutoMapper;
using DSA.BLL.Dto.Customers;
using DSA.Domain.Customers;

namespace DSA.BLL.Mapper
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
