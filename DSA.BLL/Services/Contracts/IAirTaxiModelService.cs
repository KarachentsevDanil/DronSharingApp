using System.Collections.Generic;
using SAT.BLL.Dto.AirTaxies;

namespace SAT.BLL.Services.Contracts
{
    public interface IAirTaxiModelService
    {
        void AddAirTaxiModel(AddAirTaxiModelDto data);

        IEnumerable<AirTaxiModelDto> GetAirTaxiModel(string term);
    }
}
