using System.Collections.Generic;
using System.Linq;
using SAT.DAL.Context;
using SAT.DAL.Repositories.Contract;
using SAT.Domain.AirTaxies;

namespace SAT.DAL.Repositories
{
    public class AirTaxiCompanyRepository : Repository<AirTaxiCompany>, IAirTaxiCompanyRepository
    {
        private readonly AirTaxiSharingContext _dbContext;

        public AirTaxiCompanyRepository(AirTaxiSharingContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<AirTaxiCompany> GetCompanies(string company)
        {
            return _dbContext.AirTaxiCompanys.Where(t => t.Name.Contains(company)).ToList();
        }
    }
}
