using System.Collections.Generic;
using SAT.Domain.AirTaxies;

namespace SAT.DAL.Repositories.Contract
{
    public interface IAirTaxiCompanyRepository : IRepository<AirTaxiCompany>
    {
        IEnumerable<AirTaxiCompany> GetCompanies(string company);
    }
}
