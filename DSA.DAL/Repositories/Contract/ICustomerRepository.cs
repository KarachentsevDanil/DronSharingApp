using System.Collections.Generic;
using SAT.Domain.Customers;

namespace SAT.DAL.Repositories.Contract
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetCustomerByTerm(string term);

        IEnumerable<Customer> GetCustomers();
    }
}
