using System.Collections.Generic;
using DSA.BLL.Dto.Customers;
using DSA.BLL.Services.Contracts;
using DSA.DAL.UnitOfWork.Contract;
using DSA.Domain.Customers;

namespace DSA.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IDronSharingUnitOfWork _unitOfWork;

        public CustomerService(IDronSharingUnitOfWork unitOfWork)
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
