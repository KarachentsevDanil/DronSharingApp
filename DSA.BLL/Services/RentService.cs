using System.Collections.Generic;
using SAT.BLL.Dto.Rents;
using SAT.BLL.Services.Contracts;
using SAT.DAL.UnitOfWork.Contract;
using SAT.Domain.Params;
using SAT.Domain.Rents;

namespace SAT.BLL.Services
{
    public class RentService : IRentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddRent(AddRentDto data)
        {
            var newRent = AutoMapper.Mapper.Map<AddRentDto, Rent>(data);
            _unitOfWork.RentRepository.Add(newRent);
            _unitOfWork.Commit();
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
