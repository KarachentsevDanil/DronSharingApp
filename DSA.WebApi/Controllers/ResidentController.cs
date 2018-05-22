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
    public class ResidentController : Controller
    {
        private readonly IResidentService _residentService;
        private readonly IResidentContactService _residentContactService;
        private readonly IResidentDoctorService _residentDoctorService;
        public ResidentController(IResidentService residentService, IResidentContactService residentContactService, IResidentDoctorService residentDoctorService)
        {
            _residentService = residentService;
            _residentContactService = residentContactService;
            _residentDoctorService = residentDoctorService;
        }

        [HttpPost]
        public IActionResult AddResident([FromBody] AddResidentDto residentDto)
        {
            _residentService.AddResident(residentDto);
            return Json(JsonResultData.Success());
        }

        [HttpPost]
        public IActionResult AddResidentDoctor([FromBody] AddResidentDoctorDto residentDoctorDto)
        {
            _residentDoctorService.AddResidentDoctor(residentDoctorDto);
            return Json(JsonResultData.Success());
        }

        [HttpPost]
        public IActionResult AddResidentContact([FromBody] AddResidentContactDto residentContactDto)
        {
            _residentContactService.AddResidentContact(residentContactDto);
            return Json(JsonResultData.Success());
        }

        [HttpGet]
        public IActionResult GetResidentById(int id)
        {
            var resident = _residentService.GetResidentById(id);
            return Json(JsonResultData.Success(resident));
        }

        [HttpPost]
        public IActionResult GetResidents([FromBody] ResidentsFilterParams filterParams)
        {
            var residents = _residentService.GetResidentsByParams(filterParams);
            return Json(JsonResultData.Success(residents));
        }
    }
}