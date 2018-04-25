using DSA.BLL.Dto.Rents;
using DSA.Domain.Params;

namespace DSA.BLL.Services.Contracts
{
    public interface IRentService
    {
        void AddRent(AddRentDto data);

        CollectionResult<RentDto> GetRentsByParams(RentsFilterParams filterParams);
    }
}
