using System.Collections.Generic;
using DSA.BLL.Dto.Drons;

namespace DSA.BLL.Services.Contracts
{
    public interface IDronModelService
    {
        void AddDronModel(AddDronModelDto data);

        IEnumerable<DronModelDto> GetDronModel(string term);
    }
}
