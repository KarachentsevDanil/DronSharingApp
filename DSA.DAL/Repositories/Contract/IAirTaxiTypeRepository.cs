using System.Collections.Generic;
using SAT.Domain.AirTaxies;

namespace SAT.DAL.Repositories.Contract
{
    public interface IAirTaxiTypeRepository : IRepository<AirTaxiType>
    {
        IEnumerable<AirTaxiType> GetAirTaxiTypes(string type);
    }
}
