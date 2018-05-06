using System.Collections.Generic;
using SAT.BLL.Dto.AirTaxies;
using SAT.Domain.Params;

namespace SAT.BLL.Services.Contracts
{
    public interface IAirTaxiTypeService
    {
        void AddAirTaxiType(AddAirTaxiTypeDto data);

        IEnumerable<AirTaxiTypeDto> GetAirTaxiTypes(string term);

        CollectionResult<AirTaxiTypeDto> GetAirTaxiTypesByParams(TaxiTypesFilterParams filterParams);
    }
}
