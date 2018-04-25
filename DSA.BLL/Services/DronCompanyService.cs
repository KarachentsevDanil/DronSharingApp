using System.Collections.Generic;
using DSA.BLL.Dto.Drons;
using DSA.BLL.Services.Contracts;
using DSA.DAL.UnitOfWork.Contract;
using DSA.Domain.Drons;

namespace DSA.BLL.Services
{
    public class DronCompanyService : IDronCompanyService
    {
        private readonly IDronSharingUnitOfWork _unitOfWork;

        public DronCompanyService(IDronSharingUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public void AddDronCompany(AddDronCompanyDto data)
        {
            var newDronCompany = AutoMapper.Mapper.Map<AddDronCompanyDto, DronCompany>(data);
            _unitOfWork.DronCompanyRepository.Add(newDronCompany);
        }

        public IEnumerable<DronCompanyDto> GetDronCompanies(string term)
        {
            var dronCompanies = _unitOfWork.DronCompanyRepository.GetCompanies(term);
            return AutoMapper.Mapper.Map<IEnumerable<DronCompany>, List<DronCompanyDto>>(dronCompanies);
        }
    }
}
