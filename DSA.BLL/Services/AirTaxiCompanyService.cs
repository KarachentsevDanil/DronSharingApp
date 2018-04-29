using System.Collections.Generic;
using SAT.BLL.Dto.AirTaxies;
using SAT.BLL.Services.Contracts;
using SAT.DAL.UnitOfWork.Contract;
using SAT.Domain.AirTaxies;

namespace SAT.BLL.Services
{
    public class AirTaxiCompanyService : IAirTaxiCompanyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AirTaxiCompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public void AddAirTaxiCompany(AddAirTaxiCompanyDto data)
        {
            var newAirTaxiCompany = AutoMapper.Mapper.Map<AddAirTaxiCompanyDto, AirTaxiCompany>(data);
            _unitOfWork.AirTaxiCompanyRepository.Add(newAirTaxiCompany);
        }

        public IEnumerable<AirTaxiCompanyDto> GetAirTaxiCompanies(string term)
        {
            var airTaxiCompanies = _unitOfWork.AirTaxiCompanyRepository.GetCompanies(term);
            return AutoMapper.Mapper.Map<IEnumerable<AirTaxiCompany>, List<AirTaxiCompanyDto>>(airTaxiCompanies);
        }
    }
}
