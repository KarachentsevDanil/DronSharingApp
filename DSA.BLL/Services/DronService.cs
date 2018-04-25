using System.Collections.Generic;
using DSA.BLL.Dto.Drons;
using DSA.BLL.Services.Contracts;
using DSA.DAL.UnitOfWork.Contract;
using DSA.Domain.Drons;
using DSA.Domain.Params;

namespace DSA.BLL.Services
{
    public class DronService : IDronService
    {
        private readonly IDronSharingUnitOfWork _unitOfWork;

        public DronService(IDronSharingUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddDron(AddDronDto data)
        {
            var newDron = AutoMapper.Mapper.Map<AddDronDto, Dron>(data);
            _unitOfWork.DronRepository.Add(newDron);
        }

        public CollectionResult<DronDto> GetDronsByParams(DronsFilterParams filterParams)
        {
            var drons = _unitOfWork.DronRepository.GetDronsByParams(filterParams);

            var result = new CollectionResult<DronDto>
            {
                TotalCount = drons.TotalCount,
                Collection = AutoMapper.Mapper.Map<IEnumerable<Dron>, List<DronDto>>(drons.Collection)
            };

            return result;
        }
    }
}
