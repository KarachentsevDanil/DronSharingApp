using System.Collections.Generic;
using SAT.BLL.Dto.AirTaxies;

namespace SAT.BLL.Services.Contracts
{
    public interface IAirTaxiTypeService
    {
        void AddAirTaxiType(AddAirTaxiTypeDto data);

        IEnumerable<AirTaxiTypeDto> GetAirTaxiTypes(string term);
    }
}
