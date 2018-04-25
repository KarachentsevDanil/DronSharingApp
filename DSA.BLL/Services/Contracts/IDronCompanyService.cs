using System;
using System.Collections.Generic;
using System.Text;
using DSA.BLL.Dto.Drons;

namespace DSA.BLL.Services.Contracts
{
    public interface IDronCompanyService
    {
        void AddDronCompany(AddDronCompanyDto data);

        IEnumerable<DronCompanyDto> GetDronCompanies(string term);
    }
}
