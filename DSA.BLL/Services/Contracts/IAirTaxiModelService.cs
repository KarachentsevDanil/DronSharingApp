using System.Collections.Generic;
using SAT.BLL.Dto.AirTaxies;
using SAT.Domain.Params;

namespace SAT.BLL.Services.Contracts
{
    public interface IAirTaxiModelService
    {
        void AddAirTaxiModel(AddAirTaxiModelDto data);

        IEnumerable<AirTaxiModelDto> GetAirTaxiModel(string term);

        CollectionResult<AirTaxiModelDto> GetAirTaxiModelsByParams(TaxiModelFilterParams filterParams);
    }
}
