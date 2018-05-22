using SAT.BLL.Dto.Rents;
using SAT.BLL.Services.Contracts;
using SAT.Domain.Params;
using SAT.WebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SAT.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RentController : Controller
    {
        private readonly IRentService _rentService;

        public RentController(IRentService rentService)
        {
            _rentService = rentService;
        }

        [HttpPost]
        public IActionResult AddRent([FromBody] AddRentDto rent)
        {
            rent.Status = Domain.Rents.RentStatus.Pending;
            var result = _rentService.AddRent(rent);
            return Json(JsonResultData.Success(result));
        }

        [HttpPost]
        public IActionResult UpdateRent([FromBody] RentDto rent)
        {
            _rentService.UpdateRent(rent);
            return Json(JsonResultData.Success());
        }

        [HttpPost]
        public IActionResult GetRentsByParams([FromBody] RentsFilterParams filterParams)
        {
            var rents = _rentService.GetRentsByParams(filterParams);
            return Json(JsonResultData.Success(rents));
        }

        [HttpPost]
        public IActionResult GetRents([FromBody] RentsFilterParams filterParams)
        {
            var rents = _rentService.GetRentsByParams(filterParams);
            return Json(rents);
        }

        [HttpGet]
        public IActionResult GetRentsForCalendarByParams(RentsFilterParams filterParams)
        {
            var rents = _rentService.GetRentsForCalendarByParams(filterParams);

            return Json(rents.Select(x => new
            {
                title = x.Title,
                start = x.Start,
                end = x.End,
                color = x.Color
            }).ToList());
        }
    }
}