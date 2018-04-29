using System.Collections.Generic;
using SAT.BLL.Dto.Customers;
using SAT.BLL.Services.Contracts;
using SAT.DAL.UnitOfWork.Contract;
using SAT.Domain.Customers;

namespace SAT.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CustomerDto GetCustomerByTerm(string term)
        {
            var customer = _unitOfWork.CustomerRepository.GetCustomerByTerm(term);
            return AutoMapper.Mapper.Map<Customer, CustomerDto>(customer);
        }

        public IEnumerable<CustomerDto> GetCustomers()
        {
            var customers = _unitOfWork.CustomerRepository.GetCustomers();
            return AutoMapper.Mapper.Map<IEnumerable<Customer>, List<CustomerDto>>(customers);
        }
    }
}
