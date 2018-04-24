using System.Collections.Generic;
using System.Linq;
using DSA.DAL.Context;
using DSA.DAL.Repositories.Contract;
using DSA.Domain.Drons;

namespace DSA.DAL.Repositories
{
    public class DronModelRepository : DronSharingRepository<DronModel>, IDronModelRepository
    {
        private readonly DronSharingContext _dbContext;

        public DronModelRepository(DronSharingContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<DronModel> GetDronModels(string model)
        {
            return _dbContext.DronModels.Where(t => t.Name.Contains(model)).ToList();
        }
    }
}
