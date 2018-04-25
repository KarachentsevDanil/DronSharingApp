using System.Collections.Generic;
using DSA.BLL.Dto.Customers;

namespace DSA.BLL.Services.Contracts
{
    public interface ICustomerService
    {
        CustomerDto GetCustomerByTerm(string term);

        IEnumerable<CustomerDto> GetCustomers();
    }
}
