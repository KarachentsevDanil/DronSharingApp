using SAT.BLL.Services.Contracts;
using SAT.Domain.Params;
using SAT.WebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAT.BLL.Dto.AirTaxies;

namespace SAT.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AirTaxiController : Controller
    {
        private readonly IAirTaxiService _airTaxiService;

        public AirTaxiController(IAirTaxiService airTaxiService)
        {
            _airTaxiService = airTaxiService;
        }

        [HttpPost]
        public IActionResult AddAirTaxi([FromBody] AddAirTaxiDto taxi)
        {
            _airTaxiService.AddAirTaxi(taxi);
            return Json(JsonResultData.Success());
        }

        [HttpPost]
        public IActionResult GetAirTaxiesByParams([FromBody] TaxiesFilterParams filterParams)
        {
            var airTaxies = _airTaxiService.GetAirTaxiesByParams(filterParams);
            return Json(JsonResultData.Success(airTaxies));
        }
    }
}