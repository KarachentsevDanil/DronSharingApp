using System.Collections.Generic;
using SAT.BLL.Dto.Customers;

namespace SAT.BLL.Services.Contracts
{
    public interface ICustomerService
    {
        CustomerDto GetCustomerByTerm(string term);

        IEnumerable<CustomerDto> GetCustomers();
    }
}
