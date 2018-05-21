using SAT.BLL.Dto.Rents;
using SAT.Domain.Params;
using System.Collections.Generic;

namespace SAT.BLL.Services.Contracts
{
    public interface IRentService
    {
        bool AddRent(AddRentDto data);

        CollectionResult<RentDto> GetRentsByParams(RentsFilterParams filterParams);

        List<RentCalendarDto> GetRentsForCalendarByParams(RentsFilterParams filterParams);
    }
}
