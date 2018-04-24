using System.Collections.Generic;
using DSA.Domain.Drons;

namespace DSA.DAL.Repositories.Contract
{
    public interface IDronCompanyRepository : IDronSharingRepository<DronCompany>
    {
        IEnumerable<DronCompany> GetCompanies(string company);
    }
}
