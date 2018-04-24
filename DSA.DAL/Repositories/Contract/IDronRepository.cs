using DSA.Domain.Drons;
using DSA.Domain.Params;

namespace DSA.DAL.Repositories.Contract
{
    public interface IDronRepository : IDronSharingRepository<Dron>
    {
        CollectionResult<Dron> GetDronsByParams(DronsFilterParams filterParams);
    }
}
