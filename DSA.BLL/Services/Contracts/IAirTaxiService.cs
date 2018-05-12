using SAT.BLL.Dto.AirTaxies;
using SAT.Domain.Params;

namespace SAT.BLL.Services.Contracts
{
    public interface IAirTaxiService
    {
        void AddAirTaxi(AddAirTaxiDto data);

        AirTaxiDto GetTaxiById(int id);

        CollectionResult<AirTaxiDto> GetAirTaxiesByParams(TaxiesFilterParams filterParams);
    }
}
