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
    public class AirTaxiModelController : Controller
    {
        private readonly IAirTaxiModelService _airTaxiModelService;

        public AirTaxiModelController(IAirTaxiModelService airTaxiModelService)
        {
            _airTaxiModelService = airTaxiModelService;
        }

        [HttpPost]
        public IActionResult AddAirTaxiModel([FromBody]AddAirTaxiModelDto airTaxiModel)
        {
            _airTaxiModelService.AddAirTaxiModel(airTaxiModel);
            return Json(JsonResultData.Success());
        }

        [HttpGet]
        public IActionResult GetAirTaxiModels(string term)
        {
            var models = _airTaxiModelService.GetAirTaxiModel(term);
            return Json(JsonResultData.Success(models));
        }
    }
}
