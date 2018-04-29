using SAT.BLL.Dto.Rents;
using SAT.Domain.Params;

namespace SAT.BLL.Services.Contracts
{
    public interface IRentService
    {
        void AddRent(AddRentDto data);

        CollectionResult<RentDto> GetRentsByParams(RentsFilterParams filterParams);
    }
}
