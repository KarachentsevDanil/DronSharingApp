using RCS.BLL.Dto.Residents;
using RCS.Domain.Params;

namespace RCS.BLL.Services.Contracts
{
    public interface IResidentService
    {
        ResidentDto GetResidentById(int id);

        void AddResident(AddResidentDto data);
        
        CollectionResult<ResidentDto> GetResidentsByParams(ResidentsFilterParams filterParams);
    }
}
