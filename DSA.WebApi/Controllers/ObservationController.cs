using RCS.BLL.Services.Contracts;
using RCS.WebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCS.BLL.Dto.Residents;
using RCS.Domain.Params;

namespace RCS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ObservationController : Controller
    {
        private readonly IObservationService _observationService;

        public ObservationController(IObservationService observationService)
        {
            _observationService = observationService;
        }

        [HttpPost]
        public IActionResult AddObservation([FromBody] AddObservationDto observationDto)
        {
            _observationService.AddObservation(observationDto);
            return Json(JsonResultData.Success());
        }

        [HttpPost]
        public IActionResult GetObservationsByParams([FromBody] ObservationParams filterParams)
        {
            var observations = _observationService.GetObservationsByParams(filterParams);
            return Json(JsonResultData.Success(observations));
        }
    }
}