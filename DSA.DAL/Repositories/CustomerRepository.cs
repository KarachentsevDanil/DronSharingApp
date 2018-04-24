using System.Collections.Generic;
using System.Linq;
using DSA.DAL.Context;
using DSA.DAL.Repositories.Contract;
using DSA.Domain.Customers;

namespace DSA.DAL.Repositories
{
    public class CustomerRepository : DronSharingRepository<Customer>, ICustomerRepository
    {
        private readonly DronSharingContext _dbContext;

        public CustomerRepository(DronSharingContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Customer GetCustomerByTerm(string term)
        {
            return _dbContext.Customers.FirstOrDefault(x => x.Email.ToUpper() == term.ToUpper());
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _dbContext.Customers.ToList();
        }
    }
}