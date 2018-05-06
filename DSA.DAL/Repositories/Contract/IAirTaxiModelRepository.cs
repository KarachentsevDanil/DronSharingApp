using System.Collections.Generic;
using SAT.Domain.AirTaxies;
using SAT.Domain.Params;

namespace SAT.DAL.Repositories.Contract
{
    public interface IAirTaxiModelRepository : IRepository<AirTaxiModel>
    {
        IEnumerable<AirTaxiModel> GetAirTaxiModels(string model);

        CollectionResult<AirTaxiModel> GetTaxiModelsByParams(TaxiModelFilterParams parameters);
    }
}
