using RCS.DAL.Context;
using RCS.DAL.Repositories.Contract;
using RCS.Domain.Residents;

namespace RCS.DAL.Repositories
{
    public class ResidentContactRepository : Repository<ResidentContact>, IResidentContactRepository
    {
        private readonly RelativeCommunicationContext _dbContext;

        public ResidentContactRepository(RelativeCommunicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
