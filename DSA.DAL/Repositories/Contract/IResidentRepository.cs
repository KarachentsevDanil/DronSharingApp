using RCS.Domain.Params;
using RCS.Domain.Residents;

namespace RCS.DAL.Repositories.Contract
{
    public interface IResidentRepository : IRepository<Resident>
    {
        CollectionResult<Resident> GetResidentsByParams(ResidentsFilterParams filterParams);

        Resident GetResidentById(int residentId);
    }
}
