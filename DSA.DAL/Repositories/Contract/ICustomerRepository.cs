using System.Collections.Generic;
using DSA.Domain.Customers;

namespace DSA.DAL.Repositories.Contract
{
    public interface ICustomerRepository : IDronSharingRepository<Customer>
    {
        Customer GetCustomerByTerm(string term);

        IEnumerable<Customer> GetCustomers();
    }
}
