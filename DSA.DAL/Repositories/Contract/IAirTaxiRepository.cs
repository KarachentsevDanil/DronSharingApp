using SAT.Domain.Params;
using SAT.Domain.AirTaxies;

namespace SAT.DAL.Repositories.Contract
{
    public interface IAirTaxiRepository : IRepository<AirTaxi>
    {
        CollectionResult<AirTaxi> GetAirTaxiesByParams(TaxiesFilterParams filterParams);

        AirTaxi GetTaxiById(int id);
    }
}
