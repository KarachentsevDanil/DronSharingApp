using System.Collections.Generic;
using DSA.BLL.Dto.Drons;
using DSA.BLL.Services.Contracts;
using DSA.DAL.UnitOfWork.Contract;
using DSA.Domain.Drons;

namespace DSA.BLL.Services
{
    public class DronModelService : IDronModelService
    {
        private readonly IDronSharingUnitOfWork _unitOfWork;

        public DronModelService(IDronSharingUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddDronModel(AddDronModelDto data)
        {
            var newDronModel = AutoMapper.Mapper.Map<AddDronModelDto, DronModel>(data);
            _unitOfWork.DronModelRepository.Add(newDronModel);
        }

        public IEnumerable<DronModelDto> GetDronModel(string term)
        {
            var dronModels = _unitOfWork.DronModelRepository.GetDronModels(term);
            return AutoMapper.Mapper.Map<IEnumerable<DronModel>, List<DronModelDto>>(dronModels);
        }
    }
}
