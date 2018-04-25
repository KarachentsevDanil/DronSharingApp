using DSA.BLL.Dto.Drons;
using DSA.Domain.Params;

namespace DSA.BLL.Services.Contracts
{
    public interface IDronService
    {
        void AddDron(AddDronDto data);

        CollectionResult<DronDto> GetDronsByParams(DronsFilterParams filterParams);
    }
}
