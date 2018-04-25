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
    public class DronTypeController : Controller
    {
        private readonly IDronTypeService _dronTypeService;

        public DronTypeController(IDronTypeService dronTypeService)
        {
            _dronTypeService = dronTypeService;
        }

        [HttpPost]
        public IActionResult AddDronType([FromBody] AddDronTypeDto dronType)
        {
            _dronTypeService.AddDronType(dronType);
            return Json(JsonResultData.Success());
        }

        [HttpGet]
        public IActionResult GetDronTypes(string term)
        {
            var types = _dronTypeService.GetDronTypes(term);
            return Json(JsonResultData.Success(types));
        }
    }
}