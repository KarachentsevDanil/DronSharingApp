using DSA.Domain.Params;
using DSA.Domain.Rents;

namespace DSA.DAL.Repositories.Contract
{
    public interface IRentRepository : IDronSharingRepository<Rent>
    {
        CollectionResult<Rent> GetRentsByParams(RentsFilterParams filterParams);
    }
}
