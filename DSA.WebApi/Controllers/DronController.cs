using DSA.BLL.Dto.Drons;
using DSA.BLL.Services.Contracts;
using DSA.Domain.Params;
using DSA.WebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DSA.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DronController : Controller
    {
        private readonly IDronService _dronService;

        public DronController(IDronService dronService)
        {
            _dronService = dronService;
        }

        [HttpPost]
        public IActionResult AddDron([FromBody] AddDronDto dron)
        {
            _dronService.AddDron(dron);
            return Json(JsonResultData.Success());
        }

        [HttpPost]
        public IActionResult GetDronsByParams([FromBody] DronsFilterParams filterParams)
        {
            var drons = _dronService.GetDronsByParams(filterParams);
            return Json(JsonResultData.Success(drons));
        }
    }
}