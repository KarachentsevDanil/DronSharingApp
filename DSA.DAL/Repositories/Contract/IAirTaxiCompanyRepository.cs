using System.Collections.Generic;
using SAT.Domain.AirTaxies;
using SAT.Domain.Params;

namespace SAT.DAL.Repositories.Contract
{
    public interface IAirTaxiCompanyRepository : IRepository<AirTaxiCompany>
    {
        IEnumerable<AirTaxiCompany> GetCompanies(string company);

        CollectionResult<AirTaxiCompany> GetCompaniesByParams(CompaniesFilterParams parameters);
    }
}
