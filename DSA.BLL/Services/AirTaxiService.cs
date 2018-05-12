using System.Collections.Generic;
using SAT.BLL.Dto.AirTaxies;
using SAT.BLL.Services.Contracts;
using SAT.DAL.UnitOfWork.Contract;
using SAT.Domain.Params;
using SAT.Domain.AirTaxies;

namespace SAT.BLL.Services
{
    public class AirTaxiService : IAirTaxiService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AirTaxiService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddAirTaxi(AddAirTaxiDto data)
        {
            var newAirTaxi = AutoMapper.Mapper.Map<AddAirTaxiDto, AirTaxi>(data);
            _unitOfWork.AirTaxiRepository.Add(newAirTaxi);
            _unitOfWork.Commit();
        }

        public CollectionResult<AirTaxiDto> GetAirTaxiesByParams(TaxiesFilterParams filterParams)
        {
            var airTaxies = _unitOfWork.AirTaxiRepository.GetAirTaxiesByParams(filterParams);

            var result = new CollectionResult<AirTaxiDto>
            {
                TotalCount = airTaxies.TotalCount,
                Collection = AutoMapper.Mapper.Map<IEnumerable<AirTaxi>, List<AirTaxiDto>>(airTaxies.Collection)
            };

            return result;
        }

        public AirTaxiDto GetTaxiById(int id)
        {
            var taxi = _unitOfWork.AirTaxiRepository.GetTaxiById(id);
            return AutoMapper.Mapper.Map<AirTaxi, AirTaxiDto>(taxi);
        }
    }
}
