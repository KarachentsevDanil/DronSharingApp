using System.Collections.Generic;
using System.Linq;
using DSA.DAL.Context;
using DSA.DAL.Repositories.Contract;
using DSA.Domain.Drons;

namespace DSA.DAL.Repositories
{
    public class DronTypeRepository : DronSharingRepository<DronType>, IDronTypeRepository
    {
        private readonly DronSharingContext _dbContext;

        public DronTypeRepository(DronSharingContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<DronType> GetDronTypes(string type)
        {
            return _dbContext.DronTypes.Where(t => t.Name.Contains(type)).ToList();
        }
    }
}
