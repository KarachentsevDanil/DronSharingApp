using System.Collections.Generic;
using SAT.Domain.AirTaxies;
using SAT.Domain.Params;

namespace SAT.DAL.Repositories.Contract
{
    public interface IAirTaxiTypeRepository : IRepository<AirTaxiType>
    {
        IEnumerable<AirTaxiType> GetAirTaxiTypes(string type);

        CollectionResult<AirTaxiType> GetTaxiTypesByParams(TaxiTypesFilterParams parameters);
    }
}
