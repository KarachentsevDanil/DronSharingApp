using System.Collections.Generic;
using SAT.BLL.Dto.AirTaxies;

namespace SAT.BLL.Services.Contracts
{
    public interface IAirTaxiCompanyService
    {
        void AddAirTaxiCompany(AddAirTaxiCompanyDto data);

        IEnumerable<AirTaxiCompanyDto> GetAirTaxiCompanies(string term);
    }
}
