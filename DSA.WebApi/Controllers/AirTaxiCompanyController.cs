using SAT.BLL.Services.Contracts;
using SAT.WebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAT.BLL.Dto.AirTaxies;
using SAT.Domain.Params;

namespace SAT.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AirTaxiCompanyController : Controller
    {
        private readonly IAirTaxiCompanyService _airTaxiCompanyService;

        public AirTaxiCompanyController(IAirTaxiCompanyService airTaxiCompanyService)
        {
            _airTaxiCompanyService = airTaxiCompanyService;
        }

        [HttpPost]
        public IActionResult AddAirTaxiCompany([FromBody]AddAirTaxiCompanyDto airTaxiCompany)
        {
            _airTaxiCompanyService.AddAirTaxiCompany(airTaxiCompany);
            return Json(JsonResultData.Success());
        }

        [HttpGet]
        public IActionResult GetAirTaxiCompanies(string company)
        {
            var companies = _airTaxiCompanyService.GetAirTaxiCompanies(company ?? string.Empty);
            return Json(JsonResultData.Success(companies));
        }

        [HttpPost]
        public IActionResult GetAirTaxiCompaniesByParams([FromBody] CompaniesFilterParams filterParams)
        {
            var companies = _airTaxiCompanyService.GetAirTaxiCompaniesByParams(filterParams);
            return Json(JsonResultData.Success(companies));
        }
    }
}
