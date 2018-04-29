using SAT.BLL.Services.Contracts;
using SAT.WebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAT.BLL.Dto.AirTaxies;

namespace SAT.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AirTaxiTypeController : Controller
    {
        private readonly IAirTaxiTypeService _airTaxiTypeService;

        public AirTaxiTypeController(IAirTaxiTypeService airTaxiTypeService)
        {
            _airTaxiTypeService = airTaxiTypeService;
        }

        [HttpPost]
        public IActionResult AddAirTaxiType([FromBody] AddAirTaxiTypeDto dronType)
        {
            _airTaxiTypeService.AddAirTaxiType(dronType);
            return Json(JsonResultData.Success());
        }

        [HttpGet]
        public IActionResult GetAirTaxiTypes(string term)
        {
            var types = _airTaxiTypeService.GetAirTaxiTypes(term);
            return Json(JsonResultData.Success(types));
        }
    }
}