using System.Collections.Generic;
using DSA.BLL.Dto.Drons;

namespace DSA.BLL.Services.Contracts
{
    public interface IDronTypeService
    {
        void AddDronType(AddDronTypeDto data);

        IEnumerable<DronTypeDto> GetDronTypes(string term);
    }
}
