using System.Collections.Generic;
using DSA.BLL.Dto.Rents;
using DSA.BLL.Services.Contracts;
using DSA.DAL.UnitOfWork.Contract;
using DSA.Domain.Params;
using DSA.Domain.Rents;

namespace DSA.BLL.Services
{
    public class RentService : IRentService
    {
        private readonly IDronSharingUnitOfWork _unitOfWork;

        public RentService(IDronSharingUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddRent(AddRentDto data)
        {
            var newRent = AutoMapper.Mapper.Map<AddRentDto, Rent>(data);
            _unitOfWork.RentRepository.Add(newRent);
        }

        public CollectionResult<RentDto> GetRentsByParams(RentsFilterParams filterParams)
        {
            var rents = _unitOfWork.RentRepository.GetRentsByParams(filterParams);

            var result = new CollectionResult<RentDto>
            {
                TotalCount = rents.TotalCount,
                Collection = AutoMapper.Mapper.Map<IEnumerable<Rent>, List<RentDto>>(rents.Collection)
            };

            return result;
        }
    }
}
