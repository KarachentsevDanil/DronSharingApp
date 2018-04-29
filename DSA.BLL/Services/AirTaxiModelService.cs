using System.Collections.Generic;
using SAT.BLL.Dto.AirTaxies;
using SAT.BLL.Services.Contracts;
using SAT.DAL.UnitOfWork.Contract;
using SAT.Domain.AirTaxies;

namespace SAT.BLL.Services
{
    public class AirTaxiModelService : IAirTaxiModelService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AirTaxiModelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddAirTaxiModel(AddAirTaxiModelDto data)
        {
            var newAirTaxiModel = AutoMapper.Mapper.Map<AddAirTaxiModelDto, AirTaxiModel>(data);
            _unitOfWork.AirTaxiModelRepository.Add(newAirTaxiModel);
        }

        public IEnumerable<AirTaxiModelDto> GetAirTaxiModel(string term)
        {
            var airTaxiModels = _unitOfWork.AirTaxiModelRepository.GetAirTaxiModels(term);
            return AutoMapper.Mapper.Map<IEnumerable<AirTaxiModel>, List<AirTaxiModelDto>>(airTaxiModels);
        }
    }
}
