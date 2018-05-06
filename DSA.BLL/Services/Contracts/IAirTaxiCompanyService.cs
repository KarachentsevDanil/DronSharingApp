using System.Collections.Generic;
using SAT.BLL.Dto.AirTaxies;
using SAT.Domain.Params;

namespace SAT.BLL.Services.Contracts
{
    public interface IAirTaxiCompanyService
    {
        void AddAirTaxiCompany(AddAirTaxiCompanyDto data);

        IEnumerable<AirTaxiCompanyDto> GetAirTaxiCompanies(string term);

        CollectionResult<AirTaxiCompanyDto> GetAirTaxiCompaniesByParams(CompaniesFilterParams filterParams);
    }
}
