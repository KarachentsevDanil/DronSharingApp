using System.Collections.Generic;
using System.Linq;
using SAT.DAL.Context;
using SAT.DAL.Repositories.Contract;
using SAT.Domain.Customers;

namespace SAT.DAL.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly AirTaxiSharingContext _dbContext;

        public CustomerRepository(AirTaxiSharingContext dbContext) : base(dbContext)
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