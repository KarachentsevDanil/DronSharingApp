using System.Collections.Generic;
using System.Linq;
using DSA.DAL.Context;
using DSA.DAL.Repositories.Contract;
using DSA.Domain.Drons;

namespace DSA.DAL.Repositories
{
    public class DronCompanyRepository : DronSharingRepository<DronCompany>, IDronCompanyRepository
    {
        private readonly DronSharingContext _dbContext;

        public DronCompanyRepository(DronSharingContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<DronCompany> GetCompanies(string company)
        {
            return _dbContext.DronCompanys.Where(t => t.Name.Contains(company)).ToList();
        }
    }
}
