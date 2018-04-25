using System.Collections.Generic;
using DSA.BLL.Dto.Drons;
using DSA.BLL.Services.Contracts;
using DSA.DAL.UnitOfWork.Contract;
using DSA.Domain.Drons;

namespace DSA.BLL.Services
{
    public class DronTypeService : IDronTypeService
    {
        private readonly IDronSharingUnitOfWork _unitOfWork;

        public DronTypeService(IDronSharingUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddDronType(AddDronTypeDto data)
        {
            var newDronType = AutoMapper.Mapper.Map<AddDronTypeDto, DronType>(data);
            _unitOfWork.DronTypeRepository.Add(newDronType);
        }

        public IEnumerable<DronTypeDto> GetDronTypes(string term)
        {
            var dronTypes = _unitOfWork.DronTypeRepository.GetDronTypes(term);
            return AutoMapper.Mapper.Map<IEnumerable<DronType>, List<DronTypeDto>>(dronTypes);
        }
    }
}
