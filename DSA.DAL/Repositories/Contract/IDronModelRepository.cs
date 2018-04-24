using System.Collections.Generic;
using DSA.Domain.Drons;

namespace DSA.DAL.Repositories.Contract
{
    public interface IDronModelRepository : IDronSharingRepository<DronModel>
    {
        IEnumerable<DronModel> GetDronModels(string model);
    }
}
