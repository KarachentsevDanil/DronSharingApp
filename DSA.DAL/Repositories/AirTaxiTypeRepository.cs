using System.Collections.Generic;
using System.Linq;
using SAT.DAL.Context;
using SAT.DAL.Repositories.Contract;
using SAT.Domain.AirTaxies;

namespace SAT.DAL.Repositories
{
    public class AirTaxiTypeRepository : Repository<AirTaxiType>, IAirTaxiTypeRepository
    {
        private readonly AirTaxiSharingContext _dbContext;

        public AirTaxiTypeRepository(AirTaxiSharingContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<AirTaxiType> GetAirTaxiTypes(string type)
        {
            return _dbContext.AirTaxiTypes.Where(t => t.Name.Contains(type)).ToList();
        }
    }
}
