using System.Collections.Generic;
using System.Linq;
using SAT.DAL.Context;
using SAT.DAL.Repositories.Contract;
using Microsoft.EntityFrameworkCore;
using SAT.Domain.AirTaxies;

namespace SAT.DAL.Repositories
{
    public class AirTaxiModelRepository : Repository<AirTaxiModel>, IAirTaxiModelRepository
    {
        private readonly AirTaxiSharingContext _dbContext;

        public AirTaxiModelRepository(AirTaxiSharingContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IEnumerable<AirTaxiModel> GetAirTaxiModels(string model)
        {
            return _dbContext.AirTaxiModels
                .Include(t => t.Company)
                .Include(t => t.Type)
                .Where(t => t.Name.Contains(model)).ToList();
        }
    }
}
