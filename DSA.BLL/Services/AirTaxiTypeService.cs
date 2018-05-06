using System.Collections.Generic;
using SAT.BLL.Dto.AirTaxies;
using SAT.BLL.Services.Contracts;
using SAT.DAL.UnitOfWork.Contract;
using SAT.Domain.AirTaxies;
using SAT.Domain.Params;

namespace SAT.BLL.Services
{
    public class AirTaxiTypeService : IAirTaxiTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AirTaxiTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddAirTaxiType(AddAirTaxiTypeDto data)
        {
            var newAirTaxiType = AutoMapper.Mapper.Map<AddAirTaxiTypeDto, AirTaxiType>(data);
            _unitOfWork.AirTaxiTypeRepository.Add(newAirTaxiType);
            _unitOfWork.Commit();
        }

        public IEnumerable<AirTaxiTypeDto> GetAirTaxiTypes(string term)
        {
            var airTaxiTypes = _unitOfWork.AirTaxiTypeRepository.GetAirTaxiTypes(term);
            return AutoMapper.Mapper.Map<IEnumerable<AirTaxiType>, List<AirTaxiTypeDto>>(airTaxiTypes);
        }

        public CollectionResult<AirTaxiTypeDto> GetAirTaxiTypesByParams(TaxiTypesFilterParams filterParams)
        {
            var airTaxies = _unitOfWork.AirTaxiTypeRepository.GetTaxiTypesByParams(filterParams);

            var result = new CollectionResult<AirTaxiTypeDto>
            {
                TotalCount = airTaxies.TotalCount,
                Collection = AutoMapper.Mapper.Map<IEnumerable<AirTaxiType>, List<AirTaxiTypeDto>>(airTaxies.Collection)
            };

            return result;
        }
    }
}
