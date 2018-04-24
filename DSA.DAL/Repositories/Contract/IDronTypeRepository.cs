using System.Collections.Generic;
using DSA.Domain.Drons;

namespace DSA.DAL.Repositories.Contract
{
    public interface IDronTypeRepository : IDronSharingRepository<DronType>
    {
        IEnumerable<DronType> GetDronTypes(string type);
    }
}
