﻿using SAT.BLL.Services.Contracts;
using SAT.WebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAT.BLL.Dto.AirTaxies;
using SAT.Domain.Params;

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
            var types = _airTaxiTypeService.GetAirTaxiTypes(term ?? string.Empty);
            return Json(JsonResultData.Success(types));
        }

        [HttpPost]
        public IActionResult GetAirTaxiTypesByParams([FromBody] TaxiTypesFilterParams filterParams)
        {
            var types = _airTaxiTypeService.GetAirTaxiTypesByParams(filterParams);
            return Json(JsonResultData.Success(types));
        }
    }
}