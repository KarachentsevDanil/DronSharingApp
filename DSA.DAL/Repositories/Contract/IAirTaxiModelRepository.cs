using System.Collections.Generic;
using SAT.Domain.AirTaxies;

namespace SAT.DAL.Repositories.Contract
{
    public interface IAirTaxiModelRepository : IRepository<AirTaxiModel>
    {
        IEnumerable<AirTaxiModel> GetAirTaxiModels(string model);
    }
}
