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
    public class DronModelController : Controller
    {
        private readonly IDronModelService _dronModelService;

        public DronModelController(IDronModelService dronModelService)
        {
            _dronModelService = dronModelService;
        }

        [HttpPost]
        public IActionResult AddDronModel([FromBody]AddDronModelDto dronModel)
        {
            _dronModelService.AddDronModel(dronModel);
            return Json(JsonResultData.Success());
        }

        [HttpGet]
        public IActionResult GetDronModels(string term)
        {
            var models = _dronModelService.GetDronModel(term);
            return Json(JsonResultData.Success(models));
        }
    }
}
