using RCS.BLL.Dto.Facilities;
using RCS.Domain.Params;

namespace RCS.BLL.Services.Contracts
{
    public interface IFacilityService
    {
        void AddFacility(AddFacilityDto data);

        CollectionResult<FacilityDto> GetFacilitiesByParams(FacilitiesFilterParams filterParams);
    }
}
