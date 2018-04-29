using SAT.Domain.Params;
using SAT.Domain.Rents;

namespace SAT.DAL.Repositories.Contract
{
    public interface IRentRepository : IRepository<Rent>
    {
        CollectionResult<Rent> GetRentsByParams(RentsFilterParams filterParams);
    }
}
