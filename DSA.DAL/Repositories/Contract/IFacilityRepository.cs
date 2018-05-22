using RCS.Domain.Facilities;
using RCS.Domain.Params;

namespace RCS.DAL.Repositories.Contract
{
    public interface IFacilityRepository : IRepository<Facility>
    {
        CollectionResult<Facility> GetFacilitiesByParams(FacilitiesFilterParams filterParams);
    }
}
