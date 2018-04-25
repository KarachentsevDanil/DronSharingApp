using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSA.BLL.Dto.Drons;
using DSA.BLL.Services.Contracts;
using DSA.WebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DSA.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DronCompanyController : Controller
    {
        private readonly IDronCompanyService _dronCompanyService;

        public DronCompanyController(IDronCompanyService dronCompanyService)
        {
            _dronCompanyService = dronCompanyService;
        }

        [HttpPost]
        public IActionResult AddDronCompany([FromBody]AddDronCompanyDto dronCompany)
        {
            _dronCompanyService.AddDronCompany(dronCompany);
            return Json(JsonResultData.Success());
        }

        [HttpGet]
        public IActionResult GetDronCompanies(string company)
        {
            var companies = _dronCompanyService.GetDronCompanies(company);
            return Json(JsonResultData.Success(companies));
        }
    }
}
